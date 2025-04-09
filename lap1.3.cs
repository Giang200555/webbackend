/* Bai 1: Quan Ly Can Bo
   - Nhap thong tin can bo (ho ten, nam sinh, gioi tinh, dia chi)
   - Phan loai can bo (Cong Nhan, Ky Su, Nhan Vien)
   - Tim kiem can bo theo ho ten
   - Hien thi danh sach can bo

using System;
using System.Collections.Generic;

class CanBo
{
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }

    public virtual void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        HoTen = Console.ReadLine();
        Console.Write("Nhap nam sinh: ");
        NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Nhap gioi tinh: ");
        GioiTinh = Console.ReadLine();
        Console.Write("Nhap dia chi: ");
        DiaChi = Console.ReadLine();
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"Ho ten: {HoTen}, Nam sinh: {NamSinh}, Gioi tinh: {GioiTinh}, Dia chi: {DiaChi}");
    }
}

class CongNhan : CanBo
{
    public string Bac { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap bac cong nhan (VD: 3/7): ");
        Bac = Console.ReadLine();
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Bac cong nhan: {Bac}");
    }
}

class KySu : CanBo
{
    public string NganhDaoTao { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap nganh dao tao: ");
        NganhDaoTao = Console.ReadLine();
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Nganh dao tao: {NganhDaoTao}");
    }
}

class NhanVien : CanBo
{
    public string CongViec { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap cong viec: ");
        CongViec = Console.ReadLine();
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Cong viec: {CongViec}");
    }
}

class QLCB
{
    private List<CanBo> danhSachCanBo = new List<CanBo>();

    public void NhapCanBoMoi()
    {
        Console.WriteLine("Chon loai can bo muon nhap:");
        Console.WriteLine("1. Cong nhan");
        Console.WriteLine("2. Ky su");
        Console.WriteLine("3. Nhan vien");
        Console.Write("Lua chon cua ban: ");
        int luaChon = int.Parse(Console.ReadLine());

        CanBo canBo = null;
        switch (luaChon)
        {
            case 1:
                canBo = new CongNhan();
                break;
            case 2:
                canBo = new KySu();
                break;
            case 3:
                canBo = new NhanVien();
                break;
            default:
                Console.WriteLine("Lua chon khong hop le!");
                return;
        }

        canBo.Nhap();
        danhSachCanBo.Add(canBo);
    }

    public void HienThiDanhSach()
    {
        Console.WriteLine("\n--- Danh sach can bo ---");
        foreach (var cb in danhSachCanBo)
        {
            cb.HienThi();
            Console.WriteLine("----------------------");
        }
    }

    public void TimKiemTheoTen(string ten)
    {
        Console.WriteLine($"\nKet qua tim kiem voi ten chua: {ten}");
        foreach (var cb in danhSachCanBo)
        {
            if (cb.HoTen.ToLower().Contains(ten.ToLower()))
            {
                cb.HienThi();
                Console.WriteLine("----------------------");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        QLCB qlcb = new QLCB();
        int luaChon;

        do
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Nhap can bo moi");
            Console.WriteLine("2. Tim kiem can bo theo ho ten");
            Console.WriteLine("3. Hien thi danh sach can bo");
            Console.WriteLine("4. Thoat");
            Console.Write("Nhap lua chon: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    qlcb.NhapCanBoMoi();
                    break;
                case 2:
                    Console.Write("Nhap ten can bo muon tim: ");
                    string ten = Console.ReadLine();
                    qlcb.TimKiemTheoTen(ten);
                    break;
                case 3:
                    qlcb.HienThiDanhSach();
                    break;
                case 4:
                    Console.WriteLine("Dang thoat chuong trinh...");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
        } while (luaChon != 4);
    }
}
*/

/*
Bai 2: Quan Ly Tai Lieu
   - Nhap thong tin tai lieu (ma tai lieu, ten nha xuat ban, so ban phat hanh)
   - Phan loai tai lieu (Sach, Tap Chi, Bao)
   - Tim kiem tai lieu theo loai
   - Hien thi danh sach tai lieu

using System;
using System.Collections.Generic;

class TaiLieu
{
    public string MaTaiLieu { get; set; }
    public string NhaXuatBan { get; set; }
    public int SoBanPhatHanh { get; set; }

    public virtual void Nhap()
    {
        Console.Write("Nhap ma tai lieu: ");
        MaTaiLieu = Console.ReadLine();
        Console.Write("Nhap ten nha xuat ban: ");
        NhaXuatBan = Console.ReadLine();
        Console.Write("Nhap so ban phat hanh: ");
        SoBanPhatHanh = int.Parse(Console.ReadLine());
    }

    public virtual void HienThi()
    {
        Console.WriteLine($"Ma: {MaTaiLieu}, NXB: {NhaXuatBan}, So ban: {SoBanPhatHanh}");
    }

    public virtual string LoaiTaiLieu()
    {
        return "Tai lieu";
    }
}

class Sach : TaiLieu
{
    public string TenTacGia { get; set; }
    public int SoTrang { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap ten tac gia: ");
        TenTacGia = Console.ReadLine();
        Console.Write("Nhap so trang: ");
        SoTrang = int.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Tac gia: {TenTacGia}, So trang: {SoTrang}");
    }

    public override string LoaiTaiLieu() => "Sach";
}

class TapChi : TaiLieu
{
    public int SoPhatHanh { get; set; }
    public int ThangPhatHanh { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap so phat hanh: ");
        SoPhatHanh = int.Parse(Console.ReadLine());
        Console.Write("Nhap thang phat hanh: ");
        ThangPhatHanh = int.Parse(Console.ReadLine());
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"So PH: {SoPhatHanh}, Thang PH: {ThangPhatHanh}");
    }

    public override string LoaiTaiLieu() => "Tap chi";
}

class Bao : TaiLieu
{
    public string NgayPhatHanh { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap ngay phat hanh (dd/mm/yyyy): ");
        NgayPhatHanh = Console.ReadLine();
    }

    public override void HienThi()
    {
        base.HienThi();
        Console.WriteLine($"Ngay PH: {NgayPhatHanh}");
    }

    public override string LoaiTaiLieu() => "Bao";
}
class QuanLyTaiLieu
{
    private List<TaiLieu> danhSach = new List<TaiLieu>();

    public void NhapTaiLieu()
    {
        Console.WriteLine("Chon loai tai lieu:");
        Console.WriteLine("1. Sach");
        Console.WriteLine("2. Tap chi");
        Console.WriteLine("3. Bao");
        Console.Write("Nhap lua chon: ");
        int chon = int.Parse(Console.ReadLine());

        TaiLieu tl = null;
        switch (chon)
        {
            case 1: tl = new Sach(); break;
            case 2: tl = new TapChi(); break;
            case 3: tl = new Bao(); break;
            default:
                Console.WriteLine("Lua chon khong hop le!");
                return;
        }

        tl.Nhap();
        danhSach.Add(tl);
    }

    public void HienThiTatCa()
    {
        Console.WriteLine("\n--- DANH SACH TAI LIEU ---");
        foreach (var tl in danhSach)
        {
            Console.WriteLine($"Loai: {tl.LoaiTaiLieu()}");
            tl.HienThi();
            Console.WriteLine("------------------------");
        }
    }

    public void TimKiemTheoLoai(string loai)
    {
        Console.WriteLine($"\n--- Tim tai lieu theo loai: {loai} ---");
        foreach (var tl in danhSach)
        {
            if (tl.LoaiTaiLieu().ToLower() == loai.ToLower())
            {
                tl.HienThi();
                Console.WriteLine("------------------------");
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        QuanLyTaiLieu qltl = new QuanLyTaiLieu();
        int luaChon;

        do
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Nhap tai lieu moi");
            Console.WriteLine("2. Hien thi danh sach tai lieu");
            Console.WriteLine("3. Tim tai lieu theo loai (Sach, Tap chi, Bao)");
            Console.WriteLine("4. Thoat");
            Console.Write("Nhap lua chon: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    qltl.NhapTaiLieu();
                    break;
                case 2:
                    qltl.HienThiTatCa();
                    break;
                case 3:
                    Console.Write("Nhap loai tai lieu muon tim: ");
                    string loai = Console.ReadLine();
                    qltl.TimKiemTheoLoai(loai);
                    break;
                case 4:
                    Console.WriteLine("Dang thoat chuong trinh...");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
        } while (luaChon != 4);
    }
}
*/