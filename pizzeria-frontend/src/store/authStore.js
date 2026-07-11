import { create } from "zustand";

const useAuthStore = create((set) => ({
  usuario: JSON.parse(localStorage.getItem("usuario")) || null,
  token: localStorage.getItem("token") || null,

  login: (datos) => {
    localStorage.setItem("token", datos.token);

    localStorage.setItem(
      "usuario",
      JSON.stringify({
        nombre: datos.nombre,
        rol: datos.rol,
      })
    );

    set({
      token: datos.token,
      usuario: {
        nombre: datos.nombre,
        rol: datos.rol,
      },
    });
  },

  logout: () => {
    localStorage.removeItem("token");
    localStorage.removeItem("usuario");

    set({
      usuario: null,
      token: null,
    });
  },
}));

export default useAuthStore;