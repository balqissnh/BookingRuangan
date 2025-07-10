using bookingruangan.Models;
using bookingruangan.Services;

namespace bookingruangan.Controllers
{
    public class RegisterController
    {
        private FormRegister _form;

        public RegisterController(FormRegister form)
        {
            _form = form;
        }

        public void HandleRegister()
        {
            var user = new RegisterModel
            {
                NamaLengkap = _form.GetNama(),
                NPM = _form.GetNpm(),
                Username = _form.GetUsername(),
                Password = _form.GetPassword()
            };

            if (string.IsNullOrWhiteSpace(user.NamaLengkap) ||
                string.IsNullOrWhiteSpace(user.NPM) ||
                string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.Password))
            {
                _form.ShowMessage("Semua kolom harus diisi!");
                return;
            }

            bool success = RegisterService.Register(user);
            if (success)
            {
                _form.ShowMessage("Registrasi berhasil. Silakan login.");
                _form.RedirectToLogin();
            }
            else
            {
                _form.ShowMessage("Registrasi gagal. Username mungkin sudah digunakan.");
            }
        }
    }
}
