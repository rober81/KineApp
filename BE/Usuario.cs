namespace BE {
	public class Usuario : Persona {

        public string Correo { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public Usuario()
        {
        }

        public Usuario(string login)
        {
            this.Login = login;
        }

        public override string ToString()
        {
            return Login;
        }
    }
}