import { Link, useLocation } from "wouter";
import useAuthStore from "../store/authStore";

function Navbar() {
  const usuario = useAuthStore((state) => state.usuario);
  const logout = useAuthStore((state) => state.logout);
  const [, setLocation] = useLocation();

  const cerrarSesion = () => {
    logout();
    setLocation("/login");
  };

  return (
    <nav className="navbar">
      <Link href="/">Inicio</Link>
      <Link href="/elementos">Pizzas</Link>

      {usuario && usuario.rol === "Admin" && (
        <Link href="/admin">Admin</Link>
      )}

      <div className="navbar-derecha">
        {usuario ? (
          <>
            <span>{usuario.nombre} ({usuario.rol})</span>
            <button onClick={cerrarSesion}>Salir</button>
          </>
        ) : (
          <Link href="/login">Login</Link>
        )}
      </div>
    </nav>
  );
}

export default Navbar;