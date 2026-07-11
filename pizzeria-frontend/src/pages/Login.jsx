import { useState } from "react";
import { useLocation } from "wouter";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import api from "../api/api";
import useAuthStore from "../store/authStore";

const loginSchema = z.object({
  email: z.string().email("Email inválido"),
  password: z.string().min(1, "La contraseña es obligatoria"),
});

function Login() {
  const [error, setError] = useState("");
  const login = useAuthStore((state) => state.login);
  const [, setLocation] = useLocation();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(loginSchema),
  });

  const enviarFormulario = async (data) => {
    try {
      setError("");

      const respuesta = await api.post("/Auth/login", data);

      login(respuesta.data);

      setLocation("/elementos");
    } catch {
      setError("Email o contraseña incorrectos.");
    }
  };

  return (
    <main className="contenedor">
      <h1>Login</h1>

      <form onSubmit={handleSubmit(enviarFormulario)} className="formulario">
        <label>Email</label>
        <input type="email" {...register("email")} />
        {errors.email && <p className="error">{errors.email.message}</p>}

        <label>Contraseña</label>
        <input type="password" {...register("password")} />
        {errors.password && <p className="error">{errors.password.message}</p>}

        {error && <p className="error">{error}</p>}

        <button type="submit">Ingresar</button>
      </form>

      <div className="credenciales">
        <p><strong>Admin:</strong> admin@pizzeria.com / 123456</p>
        <p><strong>User:</strong> user@pizzeria.com / 123456</p>
      </div>
    </main>
  );
}

export default Login;