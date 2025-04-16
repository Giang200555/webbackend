using System;
using System.Collections.Generic;

namespace lab15;
class Bai1
{
    public int Tu { get; set; }
    public int Mau { get; set; }

    public Bai1()
    {
        Tu = 0;
        Mau = 1;
    }

    public void Nhap()
    {
        Console.Write("Nhập tử số: ");
        Tu = int.Parse(Console.ReadLine());
        Console.Write("Nhập mẫu số: ");
        Mau = int.Parse(Console.ReadLine());
        if (Mau == 0)
        {
            Console.WriteLine("Mẫu số phải khác 0! Mặc định mẫu = 1.");
            Mau = 1;
        }
    }

    public static PhanSo Cong(PhanSo a, PhanSo b)
    {
        int tuMoi = a.Tu * b.Mau + b.Tu * a.Mau;
        int mauMoi = a.Mau * b.Mau;
        return RutGon(new PhanSo { Tu = tuMoi, Mau = mauMoi });
    }

    public static PhanSo RutGon(PhanSo ps)
    {
        int gcd = GCD(Math.Abs(ps.Tu), Math.Abs(ps.Mau));
        ps.Tu /= gcd;
        ps.Mau /= gcd;
        return ps;
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        return $"{Tu}/{Mau}";
    }
}

class Program
{
    static void Main(string[] args)
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
}
