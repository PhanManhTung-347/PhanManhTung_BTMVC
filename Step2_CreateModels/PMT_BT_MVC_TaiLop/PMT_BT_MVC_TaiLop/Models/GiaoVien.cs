namespace PMT_Baitap_MVCTaiLop.Models
{
    public class GiaoVien
    {
        public int GiaoVienId { get; set; }
        public string tenGV { get; set; }
        public ICollection<LopHocPhan> lopHocPhans { get; set; }
    }
}
