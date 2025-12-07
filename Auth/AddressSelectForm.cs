using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ChattingAppTeam6.Auth
{
    public partial class AddressSelectForm : Form
    {
        private static readonly HttpClient http = new HttpClient();
        private string selectedAddr;
        private string selectedZip;

        public string Address { get; private set; }
        public string ZipCode { get; private set; }

        private int currentPage = 1; // 현재 페이지
        private const int countPerPage = 50; // 페이지당 표시 항목 수
        private string keyword = "";

        public AddressSelectForm(string keyword)
        {
            InitializeComponent();
            this.keyword = keyword;
        }

        private async void AddressSelectForm_Load(object sender, EventArgs e)
        {
            DetailAddressBox.Visible = false;
            BackButton.Visible = false;

            PageLabel.Text = $"현재 페이지: {currentPage}";

            await LoadAddressList(keyword, currentPage);
        }

        // 주소 리스트 API 호출 및 로드
        private async Task LoadAddressList(string keyword, int page)
        {
            string apiKey = "devU01TX0FVVEgyMDI1MTEyMTE1NDk0MjExNjQ4MTI=";

            string url = $"https://business.juso.go.kr/addrlink/addrLinkApi.do" +
                         $"?confmKey={apiKey}&currentPage={page}&countPerPage={countPerPage}" +
                         $"&keyword={Uri.EscapeDataString(keyword)}&resultType=json";

            try
            {
                var response = await http.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                var doc = JsonDocument.Parse(json);
                var jusoArray = doc.RootElement.GetProperty("results").GetProperty("juso");

                AddressGrid.Rows.Clear();

                AddressGrid.ColumnCount = 2;
                AddressGrid.Columns[0].Name = "주소";
                AddressGrid.Columns[1].Name = "우편번호";

                AddressGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                AddressGrid.Columns[1].Width = 160;

                foreach (var item in jusoArray.EnumerateArray())
                {
                    AddressGrid.Rows.Add(
                        item.GetProperty("roadAddr").GetString(),
                        item.GetProperty("zipNo").GetString()
                    );
                }

                PageLabel.Text = $"Page {currentPage}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("주소 검색 오류: " + ex.Message);
            }
        }

        // 더블클릭 시 상세주소 입력 단계로 이동
        private void AddressGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedAddr = AddressGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedZip = AddressGrid.Rows[e.RowIndex].Cells[1].Value.ToString();

                AddressBox.Visible = false;
                PageLabel.Visible = false;
                BackButton.Visible = true;
                OpenDetailAddress(selectedAddr);
            }
        }

        // 상세주소 입력 창 열기
        private void OpenDetailAddress(string addr)
        {
            DetailAddressBox.Visible = true;
            AddressLabel.Text = addr;
        }

        // 상세 주소 입력 후 완료
        private void ConfirmBtutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DetailAddrBox.Text))
            {
                MessageBox.Show("상세주소를 입력해주세요.");
                return;
            }

            Address = $"{selectedAddr} {DetailAddrBox.Text}";
            ZipCode = selectedZip;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 돌아가기 버튼
        private void BackButton_Click(object sender, EventArgs e)
        {
            DetailAddressBox.Visible = false;
            AddressBox.Visible = true;
            BackButton.Visible = false;
        }

        // 이전 페이지
        private async void PrevButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                await LoadAddressList(keyword, currentPage);
            }
        }

        // 다음 페이지
        private async void NextButton_Click(object sender, EventArgs e)
        {
            currentPage++;
            await LoadAddressList(keyword, currentPage);
        }
    }
}
