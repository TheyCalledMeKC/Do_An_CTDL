using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Doan;
using System.Diagnostics;
using static Doan.FileHTML;
using ĐỒ_ÁN_NHÓM_1.Objects;
namespace Doan
{

	public partial class Form1 : Form
	{
		DSFileHTML dsFileHTML = new DSFileHTML();
		public Form1()
		{
			InitializeComponent();
		}
	
		private void Form1_Load(object sender, EventArgs e)
		{
			UpdateListView();
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			string fileThayDoi = rtbXulyFile.Text.Trim();//Lấy nội dung đã xử lý
			fileThayDoi = fileThayDoi.Replace("<!DOCTYPE html>", "").Trim();//Loại bỏ khai báo DOCTYPE và TRIM lại

			// Làm sạch dòng dư 'html'
			string[] lines = fileThayDoi.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);//Tách chuỗi thành mảng mới
			lines = lines.Where(line => line.Trim() != "html").ToArray();//Loại bỏ dòng khi chỉ chứa html
			fileThayDoi = string.Join(Environment.NewLine, lines);

			if (lvFile1.SelectedItems.Count > 0)
			{
				//Xử lý tìm file được chọn trong danh sách
				string selectedItem = lvFile1.SelectedItems[0].Text;

				FileHTML selectedFile = null;
				int queueSize = dsFileHTML.demDS();
				DSFileHTML tempQueue = new DSFileHTML();

				//Duyệt danh sách tìm file tương ứng
				for (int i = 0; i < queueSize; i++)
				{
					FileHTML file = dsFileHTML.dequeueDS();
					if (file.tenFile.Equals(selectedItem))
					{
						selectedFile = file;
					}
					tempQueue.enqueueDS(file);
				}

				//Đưa lại dữ liệu vào DSFileHTML
				while (tempQueue.demDS() > 0)
				{
					dsFileHTML.enqueueDS(tempQueue.dequeueDS());
				}

				if (selectedFile != null)
				{
					//Kiểm tra cú pháp file trước khi lưu
					bool isValid = selectedFile.KiemTraNoiDung(fileThayDoi);

					if (isValid)
					{
						// Nếu chưa có url thì chọn nơi lưu mới
						if (string.IsNullOrWhiteSpace(selectedFile.url))
						{
							SaveFileDialog saveFileDialog = new SaveFileDialog();
							saveFileDialog.Filter = "HTML Files (.html)|.html|All Files (.)|*.*";
							saveFileDialog.Title = "Chọn nơi lưu file HTML";

							if (saveFileDialog.ShowDialog() == DialogResult.OK)
							{
								//Lưu file mới
								selectedFile.url = saveFileDialog.FileName;
								selectedFile.tenFile = Path.GetFileName(saveFileDialog.FileName);

								// Ghi file
								File.WriteAllText(selectedFile.url, fileThayDoi);

								// Cập nhật queue
								if (!dsFileHTML.daTonTai(selectedFile.url))
								{
									dsFileHTML.enqueueDS(new FileHTML(selectedFile.url));
								}
								UpdateListView();

								// Mở thư mục chứa file
								Process.Start("explorer.exe", Path.GetDirectoryName(selectedFile.url));

								MessageBox.Show("Đã lưu và mở thư mục chứa file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						else
						{
							// Đã có đường dẫn: lưu đè
							File.WriteAllText(selectedFile.url, fileThayDoi);
							MessageBox.Show("Lưu đè thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
					else
					{
						//Báo cáo lỗi cú pháp
						MessageBox.Show("Cú pháp HTML vẫn còn lỗi. Vui lòng kiểm tra lại trước khi lưu!", "Lỗi cú pháp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn file cần lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}


		private void btnThem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "HTML/TXT Files (.html;.htm;*.txt)|*.html;*.htm;*.txt";
			openFileDialog.Title = "Chọn file HTML";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string selectedFilePath = Path.GetFullPath(openFileDialog.FileName);

				// Kiểm tra xem file có phải là file HTML hợp lệ không
				if (!IsHtmlFile(selectedFilePath))
				{
					MessageBox.Show("Vui lòng chọn một file HTML hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Kiểm tra xem file đã tồn tại trong danh sách dựa trên đường dẫn đầy đủ (url)
				if (dsFileHTML.daTonTai(selectedFilePath))
				{
					MessageBox.Show("File đã tồn tại trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				// Thêm file mới vào danh sách
				FileHTML newFile = new FileHTML(selectedFilePath);
				dsFileHTML.enqueueDS(newFile);
				UpdateListView();

				MessageBox.Show("Đã thêm file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		private void rtbFileHTML_TextChanged(object sender, EventArgs e)
		{

		}
		private void btnHienThi_Click(object sender, EventArgs e)
		{

			rtbXulyFile.Enabled = false;
			txtNoiDung.Clear(); // Xóa nội dung cũ

			if (lvFile1.SelectedItems.Count > 0)
			{
				string selectedItem = lvFile1.SelectedItems[0].Text;
				FileHTML selectedFile = null;

				int queueSize = dsFileHTML.demDS();
				DSFileHTML temp = new DSFileHTML();

				//Duyệt tìm file
				for (int i = 0; i < queueSize; i++)
				{
					FileHTML file = dsFileHTML.dequeueDS();
					if (file.tenFile.Equals(selectedItem))
					{
						selectedFile = file;
					}
					temp.enqueueDS(file);
				}

				while (temp.demDS() > 0)
				{
					dsFileHTML.enqueueDS(temp.dequeueDS());
				}

				if (selectedFile != null)
				{
					//Hiển thị nội dung file HTML
					string html = selectedFile.LayNoiDungFile(selectedFile.url);
					rtbXulyFile.Text = html;

					//Nếu HTML hợp lệ thì trích nội dung ra
					bool isValid = selectedFile.KiemTraNoiDung(html);

					if (isValid)
					{
						txtNoiDung.Text = selectedFile.LayNoiDungSach(html);
					}
					else
					{
						MessageBox.Show(
							"Cú pháp HTML không hợp lệ. Nếu muốn sửa, vui lòng nhấn nút 'Chỉnh sửa'.",
							"Lỗi cú pháp",
							MessageBoxButtons.OK,
							MessageBoxIcon.Warning
						);
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một file HTML trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private bool IsHtmlFile(string filePath)
		{
			//Kiểm tra phần mở rộng file có hợp lệ không
			string extension = Path.GetExtension(filePath);
			return (extension.Equals(".html", StringComparison.OrdinalIgnoreCase) ||
					extension.Equals(".htm", StringComparison.OrdinalIgnoreCase)) ||
					extension.Equals(".txt", StringComparison.OrdinalIgnoreCase);

		}
		private void UpdateListView()
		{
			//Cập nhật lại danh sách file trên ListView	
			lvFile1.Items.Clear();

			for (int i = 0; i < dsFileHTML.demDS(); i++)
			{
				FileHTML file = (FileHTML)dsFileHTML.layNode(i).data;


				ListViewItem item = new ListViewItem(file.tenFile);
				lvFile1.Items.Add(item);
			}
		}
		private void Xóa_Click(object sender, EventArgs e)
		{
			//Xóa file HTML được chọn trong danh sách
			if (lvFile1.SelectedItems.Count > 0)
			{
				string selectedItem = lvFile1.SelectedItems[0].Text;
				DSFileHTML temp = new DSFileHTML();
				int index = dsFileHTML.demDS();
				for (int i = 0; i < index; i++)
				{
					//FileHTML file = (FileHTML)dsFileHTML.layNode(i).data; 
					FileHTML file = dsFileHTML.dequeueDS();
					if (!file.tenFile.Equals(selectedItem))
					{
						temp.enqueueDS(file);
					}
				}
				while (temp.demDS() != 0)
				{
					dsFileHTML.enqueueDS(temp.dequeueDS());
				}
				UpdateListView();
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một file HTML!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

        private void btnEdit_Click(object sender, EventArgs e)
        {
			//Kiểm tra nếu không có nội dung thì không xử lý
            if (rtbXulyFile == null || string.IsNullOrWhiteSpace(rtbXulyFile.Text))
            {
                MessageBox.Show("Không có nội dung để xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
			
			//Tách nội dung thành từng dòng
            string[] lines = rtbXulyFile.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            //Queue lưu các dòng để xử lý tuần tự
			Queue<string> inputQueue = new Queue<string>(lines);
			//Queue lưu các thẻ đang mở nhưng chưa đóng
            Queue<string> openTags = new Queue<string>();
			//List lưu kết quả sau chỉnh sửa
            List<string> result = new List<string>();
			//List gom các thẻ đóng còn thiếu
            List<string> tagDongThemSau = new List<string>(); 
            //Theo dõi trạng thái
			bool hasFix = false, htmlOpened = false, htmlClosed = false;
            bool bodyOpened = false, bodyClosed = false;

            // Danh sách các thẻ tự đóng
            HashSet<string> selfClosingTags = new HashSet<string> { "br", "img", "input", "hr", "meta", "link" };

            var regexes = new
            {
                Open = new Regex(@"^<([a-zA-Z0-9]+)(?:\s+[^>]*)?>$", RegexOptions.Compiled),//Thẻ mở
                Close = new Regex(@"^</([a-zA-Z0-9]+)>$", RegexOptions.Compiled),//Thẻ đóng
                SelfClosing = new Regex(@"^<([a-zA-Z0-9]+)(?:\s+[^>]*)?/>$", RegexOptions.Compiled), // Thẻ tự đóng
                CorrectInline = new Regex(@"^<([a-zA-Z0-9]+)>(.*?)</\1>$", RegexOptions.Compiled),//Thẻ mở+đóng đúng chuẩn
                MissingOpenBracket = new Regex(@"^(?!/)([a-zA-Z0-9]+)>$", RegexOptions.Compiled),//Thiếu dấu < ở đầu
                MissingCloseBracket = new Regex(@"^/([a-zA-Z0-9]+)>$", RegexOptions.Compiled),//Thiếu < ở thẻ đóng
                MissingEndGt = new Regex(@"^<[^>]+[^>]$", RegexOptions.Compiled),//Thiếu > ở cuối
                IncompleteInline = new Regex(@"^<([a-zA-Z0-9]+)>(.*?)<(?!/)\1$", RegexOptions.Compiled),//Mở nhưng chưa đóng hết
                DuplicateInline = new Regex(@"^<([a-zA-Z0-9]+)>(.*?)<\1>$", RegexOptions.Compiled),//Trùng thẻ mở
                NestedError = new Regex(@"<([a-zA-Z0-9]+)[^>]*>.*?</([a-zA-Z0-9]+)>.*?</\1>", RegexOptions.Compiled), // Lồng ghép sai
                AttributeFix = new Regex(@"<([a-zA-Z0-9]+)(\s+[^>]+[^/>])$", RegexOptions.Compiled) // Thẻ có thuộc tính thiếu >
            };


			//Hàm phụ: gói nội dung trong thẻ tag
            string WrapTag(string tag, string content) => $"<{tag}>{content}</{tag}>";

			//Hàm sửa từng dòng
            string FixLine(string line)
            {
                if (regexes.CorrectInline.IsMatch(line)) return line;

                // Sửa thẻ thiếu dấu >
                if (regexes.AttributeFix.Match(line) is Match attrMatch && attrMatch.Success)
                {
                    hasFix = true;
                    return $"<{attrMatch.Groups[1].Value}{attrMatch.Groups[2].Value}>";
                }

                // Phát hiện lồng ghép sai (ví dụ: <p><span>Hello</p></span>)
                if (regexes.NestedError.Match(line) is Match nestedMatch && nestedMatch.Success)
                {
                    string outerTag = nestedMatch.Groups[1].Value;
                    string innerTag = nestedMatch.Groups[2].Value;
                    hasFix = true;
                    // Sửa bằng cách đóng thẻ trong trước thẻ ngoài
                    return Regex.Replace(line, $@"</{innerTag}>.*?</{outerTag}>", $"</{innerTag}></{outerTag}>");
                }

				//Nếu thiếu dấu < ở đầu
                if (Regex.IsMatch(line, @"^[a-zA-Z0-9]+>") && !line.StartsWith("<"))
                {
                    string tag = line.Substring(0, line.IndexOf('>'));
                    return $"<{tag}>{line.Substring(tag.Length + 1)}";
                }

				//Sửa thẻ mở chưa đóng hoàn chỉnh
                if (regexes.IncompleteInline.Match(line) is Match m1 && m1.Success)
                    return WrapTag(m1.Groups[1].Value, m1.Groups[2].Value);

				//Sửa lỗi trùng lặp thẻ mở
                if (regexes.DuplicateInline.Match(line) is Match m2 && m2.Success)
                    return WrapTag(m2.Groups[1].Value, m2.Groups[2].Value);


			//Phát hiện mở thẻ body khi đã có, thì tự động đóng trước
                Match doubleOpen = Regex.Match(line, @"<([a-zA-Z0-9]+)>");
                if (doubleOpen.Success)
                {
                    string tag = doubleOpen.Groups[1].Value;
                    if (tag == "body" && bodyOpened && !bodyClosed)
                    {
                        hasFix = true;
                        return $"</body>";
                    }
                }

				//Sửa thẻ thiếu dấu < đầu dòng
                if (regexes.MissingOpenBracket.Match(line) is Match m3 && m3.Success)
                    return $"<{m3.Groups[1].Value}>";

				//Sửa thẻ thiếu dấu < ở thẻ đóng
                if (regexes.MissingCloseBracket.Match(line) is Match m4 && m4.Success)
                    return $"</{m4.Groups[1].Value}>";

				//Nếu thiếu dấu > thì thêm vào cuối dòng
                if (regexes.MissingEndGt.IsMatch(line))
                    return line + ">";

				//Nếu dòng chưa đủ < hoặc > thì thêm dấu >
				if (Regex.IsMatch(line, @"</?[a-zA-Z0-9]+[^>]*$"))
                    return line + ">";

				//Nếu không có lỗi gì thì giữ nguyên
                return line;
            }

			//Hàm thêm thẻ đóng vào danh sách
            void AddClosingTag(string tag)
            {
                if (tag == "html" && htmlClosed) return;
                if (tag == "body" && bodyClosed) return;
                if (tag == "html") htmlClosed = true;
                if (tag == "body") bodyClosed = true;
                tagDongThemSau.Add($"</{tag}>");
                hasFix = true;
            }

            try
            {
                bool needAnotherPass = true; //Biến này để theo dõi xem có cần chạy lại không

				//Chạy vòng lặp cho đến khi không còn lỗi nào nữa
				while (needAnotherPass)
                {
                    needAnotherPass = false;

                    Queue<string> tempInput = new Queue<string>(inputQueue.Count > 0 ? inputQueue : new Queue<string>(rtbXulyFile.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)));
					//Lưu lại nội dung tạm thời
					inputQueue.Clear();
                    result.Clear();
                    tagDongThemSau.Clear();
                    openTags.Clear();
                    htmlOpened = htmlClosed = false;
                    bodyOpened = bodyClosed = false;

                    while (tempInput.Count > 0)
                    {
                        string line = tempInput.Dequeue().TrimEnd();
						//Nếu dòng trống thì bỏ qua
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            result.Add(line);
                            continue;
                        }

						//Sửa từng dòng
                        string fixedLine = FixLine(line);
                        if (fixedLine != line)
                        {
                            hasFix = true;
                            needAnotherPass = true;
                            line = fixedLine;
                        }

						//Nếu là thẻ đóng
                        if (regexes.SelfClosing.Match(line) is Match selfClosingMatch && selfClosingMatch.Success)
                        {
                            result.Add(line); // Bỏ qua thẻ tự đóng
                            continue;
                        }

						//Nếu là thẻ mở
                        if (regexes.Open.Match(line) is Match openMatch && openMatch.Success)
                        {
                            string tag = openMatch.Groups[1].Value.ToLower();
                            if (selfClosingTags.Contains(tag))
                            {
                                result.Add(line);
                                continue;
                            }
                            if (tag == "html")
                            {
                                if (htmlOpened) continue;
                                htmlOpened = true;
                            }
                            if (tag == "body")
                            {
                                if (bodyOpened)
                                {
                                    line = "</body>";
                                    bodyClosed = true;
                                    hasFix = true;
                                }
                                else
                                {
                                    bodyOpened = true;
                                }
                            }
                            if (!bodyClosed || tag != "body")
                                openTags.Enqueue(tag);
                            result.Add(line);
                            continue;
                        }

						//Nếu là thẻ đóng
                        if (regexes.Close.Match(line) is Match closeMatch && closeMatch.Success)
                        {
                            string tag = closeMatch.Groups[1].Value.ToLower();

                            if (tag == "html")
                            {
                                if (htmlClosed) continue;
                                htmlClosed = true;
                            }
                            if (tag == "body")
                            {
                                if (bodyClosed) continue;
                                bodyClosed = true;
                            }

                            if (openTags.Contains(tag))
                            {
                                var temp = openTags.ToList();
                                openTags.Clear();
                                bool matched = false;

                                foreach (var t in temp)
                                {
                                    if (t == tag && !matched)
                                    {
                                        matched = true;
                                        continue;
                                    }
                                    openTags.Enqueue(t);
                                }
                                result.Add(line);
                            }
                            else
                            {
                                AddClosingTag(tag);
                            }
                            continue;
                        }

						//Nếu không phải thẻ đặc biệt thì thêm vào kết quả
                        result.Add(line);
                    }

					//Sau cùng thêm các thẻ đóng còn thiếu
                    while (openTags.Count > 0)
                        AddClosingTag(openTags.Dequeue());

                    result.AddRange(tagDongThemSau);

					//Gán kết quả cho vòng lặp kế tiếp
                    inputQueue = new Queue<string>(result);
                }

				//Gán kết quả cuối cùng vào XulyFile
				rtbXulyFile.Text = string.Join(Environment.NewLine, result);

				//Thông báo kết quả
                MessageBox.Show(
                    hasFix ? "Đã tự động sửa cú pháp HTML và hiển thị lại chuẩn." : "Không có lỗi nào để chỉnh sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
				//Báo cáo nếu có Exception
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

	}
}
