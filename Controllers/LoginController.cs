using System.Windows.Forms;
using bookingruangan.Models;
using bookingruangan.Views;

namespace bookingruangan.Controllers
{
    public class LoginController
    {
        private login _view;

        public LoginController(login view)
        {
            _view = view;
        }

        public void HandleLogin(string username, string password)
        {
            if (LoginService.Authenticate(username, password))
            {
                MessageBox.Show("Login Berhasil");
                _view.Hide();
                sewa form1 = new sewa();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Login Gagal");
            }
        }
    }
}
