using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Doan;
using ĐỒ_ÁN_NHÓM_1.Objects;



namespace Doan
{
	public class FileHTML
	{
		//upload file => Cảnh báo file không đúng, đúng thì hiện nội dung của file (Queue => Kiểm tra tính hợp lệ).
		//Ở class nào ? FileHTML hay DSFileHTML =? DSFileHTML => Hàm check
		//Chỉnh sửa file
		//Lưu file lại vị trí
		//Trích xuất liên kết từ file HTML (Queue => Tìm kiếm và trích xuất)
		//Upload file
		public string url { get; set; }
		public string tenFile { get; set; }
		public string noiDung { get; set; }
		public FileHTML(string url)
		{
			this.url = url;
			tenFile = LayTenFile(url);
			noiDung = LayNoiDungFile(url);
		}

		public string LayTenFile(string url)
		{
			string tenFile = Path.GetFileName(url);
			return tenFile;
		}

		public string LayNoiDungFile(string url)
		{
			string noiDung = File.ReadAllText(url);
			noiDung = noiDung.Replace("<!DOCTYPE html>", "");


			return noiDung;
		}
		//Upload File
		public string taiFileHTML()
		{
			string htmlContent = File.ReadAllText(url);
			return htmlContent;
		}

		//kiemTraNoiDungFile
		MyQueue tagMo = new MyQueue();
		MyQueue tagDong = new MyQueue();
        public bool KiemTraNoiDung(string html)
        {
            Queue<string> openTags = new Queue<string>();
            Regex tagRegex = new Regex("<[^>]+>");
            MatchCollection tagMatches = tagRegex.Matches(html);

            // Tách tất cả thẻ
            foreach (Match tagMatch in tagMatches)
            {
                string tag = tagMatch.Value.Trim('<', '>', ' ').ToLower();

                if (!tag.StartsWith("/"))
                {
                    // Thẻ mở → đưa vào queue
                    openTags.Enqueue(tag);
                }
                else
                {
                    // Thẻ đóng
                    string closingTag = tag.Substring(1);

                    // Tìm xem có thẻ mở nào khớp không
                    bool found = false;
                    int count = openTags.Count;

                    for (int i = 0; i < count; i++)
                    {
                        string openTag = openTags.Dequeue();
                        if (!found && openTag == closingTag)
                        {
                            found = true; // tìm được → loại nó khỏi queue
                            break;
                        }
                        else
                        {
                            openTags.Enqueue(openTag); // giữ lại thẻ không khớp
                        }
                    }

                    if (!found)
                    {
                        return false; // không tìm được thẻ mở phù hợp
                    }
                }
            }

            // Nếu còn thẻ mở mà không có thẻ đóng tương ứng
            return openTags.Count == 0;
        }

        public static List<string> PhanTichLoiHTML_Queue(string html)
        {
            Queue<string> queue = new Queue<string>();
            List<string> loi = new List<string>();

            Regex regex = new Regex(@"<(/?)([a-zA-Z0-9]+)[^>]*>");
            MatchCollection matches = regex.Matches(html);

            foreach (Match match in matches)
            {
                string tag = match.Groups[2].Value.ToLower();
                bool isClosing = match.Groups[1].Value == "/";

                if (!isClosing)
                {
                    queue.Enqueue(tag);
                }
                else
                {
                    // Kiểm tra trong hàng đợi có thẻ mở khớp không
                    bool found = false;
                    int size = queue.Count;
                    for (int i = 0; i < size; i++)
                    {
                        string openTag = queue.Dequeue();
                        if (!found && openTag == tag)
                        {
                            // Tìm được thẻ khớp → đánh dấu là đã xử lý
                            found = true;
                            break;
                        }
                        else
                        {
                            // Nếu chưa tìm được thì enqueue lại để giữ thứ tự
                            queue.Enqueue(openTag);
                        }
                    }

                    if (!found)
                    {
                        loi.Add($"</{tag}>");
                    }
                }
            }

            // Những thẻ mở còn dư trong hàng đợi cũng là lỗi
            while (queue.Count > 0)
            {
                loi.Add($"<{queue.Dequeue()}>");
            }

            return loi;
        }
		


        public string LayNoiDungSach(string html)
		{
			// Thêm \n sau thẻ đóng thường dùng để đảm bảo xuống dòng
			string formattedHtml = Regex.Replace(html, @"</(p|div|span|h[1-6]|li|tr)>", "</$1>\n", RegexOptions.IgnoreCase);

			// Xoá tất cả các thẻ HTML
			string plainText = Regex.Replace(formattedHtml, "<.*?>", "");

			// Cắt theo dòng và loại bỏ dòng trống, đồng thời trim từng dòng
			string[] lines = plainText
				.Split('\n')
				.Select(line => line.Trim())
				.Where(line => !string.IsNullOrEmpty(line))
				.ToArray();

			// Ghép lại thành text hoàn chỉnh với mỗi dòng là 1 nội dung rõ ràng
			return string.Join(Environment.NewLine, lines);
		}
		//inNoiDungDung
		public string inNoiDungDung(string html)
		{
			string contentWithoutTags = Regex.Replace(html, @"<[^>]+>", match =>
			{
				string tagName = Regex.Match(match.Value, @"<(\w+)").Groups[1].Value;
				if (tagName.ToLower() != "script" && tagName.ToLower() != "style")
				{
					return $"{match.Groups[1].Value}\n";
				}
				else
				{
					return "";
				}
			}).Trim();
			return contentWithoutTags;
		}

		public MyQueue inNoiDungSai()
		{
			MyQueue temp = new MyQueue();
			if (tagDong.Count() != 0)
			{
				temp.Enqueue(tagDong.Dequeue().data);
			}
			if (tagMo.Count() != 0)
			{
				temp.Enqueue(tagMo.Dequeue().data);
			}
			return temp;

		}
		public static string SuaTheHTMLLoi(string html)
		{
			// 1. Sửa lỗi thiếu dấu '>' ở cuối thẻ mở (ví dụ: <p -> <p>)
			html = Regex.Replace(html, @"<([a-zA-Z0-9]+)([^<>]*)(?=\n|$)", "<$1$2>");

			// 2. Xóa các dòng trắng hoặc thừa ký tự không cần thiết
			html = Regex.Replace(html, @"\s*<", "<");  // Xóa khoảng trắng trước thẻ
			html = Regex.Replace(html, @">\s*", ">");  // Xóa khoảng trắng sau thẻ
			html = Regex.Replace(html, @"\s*\n\s*", "\n"); // Xử lý xuống dòng gọn gàng

			// 3. Tách mỗi thẻ thành một dòng riêng biệt
			html = Regex.Replace(html, @"(?<=>)(?=<)", "\n");

			// 4. Làm sạch từng dòng
			string[] lines = html.Split('\n');
			List<string> cleanLines = new List<string>();
			foreach (string line in lines)
			{
				string trimmed = line.Trim();
				if (!string.IsNullOrEmpty(trimmed))
					cleanLines.Add(trimmed);
			}

			// 5. Ghép lại kết quả cuối cùng
			return string.Join(Environment.NewLine, cleanLines);
		}
	}
}