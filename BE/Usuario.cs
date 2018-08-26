namespace BE {
	public class Usuario : Persona {

        public string Correo { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public override string ToString()
        {
            return Login;
        }
    }
}