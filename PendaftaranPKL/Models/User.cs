namespace PendaftaranPKL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Sekolah { get; set; }
    }
}
