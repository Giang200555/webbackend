using System;
using System.Collections.Generic;
using System.Linq;
using lab15;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n======== MENU ========");
            Console.WriteLine("1. Tính tổng các phân số");
            Console.WriteLine("2. Tính chu vi và diện tích các hình");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
            string luaChon = Console.ReadLine();

            switch (luaChon)
            {
                case "1":
                    TinhTongPhanSo();
                    break;
                case "2":
                    TinhChuViDienTich();
                    break;
                case "0":
                    Console.WriteLine("Thoát chương trình.");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }

    static void TinhTongPhanSo()
    {
        List<PhanSo> danhSach = new List<PhanSo>();
        Console.Write("Nhập số lượng phân số: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Phân số thứ {i + 1}:");
            PhanSo ps = new PhanSo();
            ps.Nhap();
            danhSach.Add(ps);
        }

        PhanSo tong = danhSach[0];
        for (int i = 1; i < danhSach.Count; i++)
        {
            tong = PhanSo.Cong(tong, danhSach[i]);
        }

        Console.WriteLine($"Tổng các phân số là: {tong}");
    }

    static void TinhChuViDienTich()
    {
        List<Hinh> danhSachHinh = new List<Hinh>
        {
            new HinhTron(3),
            new HinhVuong(4),
            new HinhChuNhat(5, 2),
            new HinhTamGiac(3, 4, 5)
        };

        double tongChuVi = danhSachHinh.Sum(h => h.TinhChuVi());
        double tongDienTich = danhSachHinh.Sum(h => h.TinhDienTich());

        Console.WriteLine($"Tổng chu vi các hình: {tongChuVi:F2}");
        Console.WriteLine($"Tổng diện tích các hình: {tongDienTich:F2}");
    }
}
