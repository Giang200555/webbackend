using System;

namespace lab15;

public abstract class Hinh
{
    public abstract double TinhChuVi();
    public abstract double TinhDienTich();
}

public class HinhTron : Hinh
{
    public double BanKinh { get; set; }
    public HinhTron(double r) => BanKinh = r;

    public override double TinhChuVi() => 2 * Math.PI * BanKinh;
    public override double TinhDienTich() => Math.PI * BanKinh * BanKinh;
}

public class HinhVuong : Hinh
{
    public double Canh { get; set; }
    public HinhVuong(double a) => Canh = a;

    public override double TinhChuVi() => 4 * Canh;
    public override double TinhDienTich() => Canh * Canh;
}

public class HinhChuNhat : Hinh
{
    public double Dai { get; set; }
    public double Rong { get; set; }

    public HinhChuNhat(double dai, double rong)
    {
        Dai = dai;
        Rong = rong;
    }

    public override double TinhChuVi() => 2 * (Dai + Rong);
    public override double TinhDienTich() => Dai * Rong;
}

public class HinhTamGiac : Hinh
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public HinhTamGiac(double a, double b, double c)
    {
        A = a; B = b; C = c;
    }

    public override double TinhChuVi() => A + B + C;

    public override double TinhDienTich()
    {
        double p = TinhChuVi() / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }
}
