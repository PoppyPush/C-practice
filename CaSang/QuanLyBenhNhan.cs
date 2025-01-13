using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBenhNhan
{
    // Struct về Bệnh nhân
    struct BenhNhan
    {
        public string MaBenhNhan;
        public string HoTen;
        public string NgayVaoVien;
        public int SoNgayNamVien; // Tính toán từ ngày nhập viện
    }

    class Program
    {
        static List<BenhNhan> danhSachBenhNhan = new List<BenhNhan>();

        // Hàm nhập thông tin bệnh nhân
        static void NhapThongTin()
        {
            Console.Write("Nhập mã bệnh nhân: ");
            string maBenhNhan = Console.ReadLine();

            // Kiểm tra trùng mã bệnh nhân
            if (danhSachBenhNhan.Any(bn => bn.MaBenhNhan == maBenhNhan))
            {
                Console.WriteLine("Mã bệnh nhân đã tồn tại. Vui lòng nhập mã khác.");
                return;
            }

            Console.Write("Nhập họ tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Nhập ngày vào viện (dd-MM-yyyy): ");
            string ngayVaoVien = Console.ReadLine();

            Console.Write("Nhập số ngày nằm viện: ");
            int soNgayNamVien = int.Parse(Console.ReadLine());

            danhSachBenhNhan.Add(new BenhNhan
            {
                MaBenhNhan = maBenhNhan,
                HoTen = hoTen,
                NgayVaoVien = ngayVaoVien,
                SoNgayNamVien = soNgayNamVien
            });

            Console.WriteLine("Đã thêm bệnh nhân thành công!");
        }

        // Hàm hiển thị danh sách bệnh nhân
        static void HienThiDanhSach()
        {
            Console.WriteLine("Danh sách bệnh nhân:");
            Console.WriteLine("{0,-15} {1,-20} {2,-15} {3,-10}", "Mã BN", "Họ tên", "Ngày vào viện", "Số ngày");
            foreach (var bn in danhSachBenhNhan)
            {
                Console.WriteLine("{0,-15} {1,-20} {2,-15} {3,-10}", bn.MaBenhNhan, bn.HoTen, bn.NgayVaoVien, bn.SoNgayNamVien);
            }
        }

        // Hàm xóa bệnh nhân
        static void XoaBenhNhan()
        {
            Console.Write("Nhập mã bệnh nhân cần xóa: ");
            string maBenhNhan = Console.ReadLine();

            var benhNhan = danhSachBenhNhan.FirstOrDefault(bn => bn.MaBenhNhan == maBenhNhan);
            if (benhNhan.MaBenhNhan == null)
            {
                Console.WriteLine("Không tìm thấy bệnh nhân với mã này.");
                return;
            }

            danhSachBenhNhan.Remove(benhNhan);
            Console.WriteLine("Đã xóa bệnh nhân thành công.");
        }

        static void Main(string[] args)
        {
            int luaChon;
            do
            {
                Console.WriteLine("\n--- Quản lý bệnh nhân ---");
                Console.WriteLine("1. Nhập thông tin");
                Console.WriteLine("2. Hiển thị danh sách");
                Console.WriteLine("3. Xóa bệnh nhân");
                Console.WriteLine("4. Thoát");
                Console.Write("Chọn chức năng: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        NhapThongTin();
                        break;
                    case 2:
                        HienThiDanhSach();
                        break;
                    case 3:
                        XoaBenhNhan();
                        break;
                    case 4:
                        Console.WriteLine("Đã thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            } while (luaChon != 4);
        }
    }
}
