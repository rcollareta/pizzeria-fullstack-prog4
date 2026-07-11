import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { z } from "zod";
import api from "../api/api";

const pizzaSchema = z.object({
  nombre: z.string().min(1, "El nombre es obligatorio"),
  descripcion: z.string().min(1, "La descripción es obligatoria"),
  precio: z.coerce.number().min(1, "El precio debe ser mayor a 0"),
  categoria: z.string().min(1, "La categoría es obligatoria"),
  imagenUrl: z.string().optional(),
});

function Admin() {
  const [dashboard, setDashboard] = useState(null);
  const [pizzas, setPizzas] = useState([]);
  const [pizzaEditando, setPizzaEditando] = useState(null);
  const [mensaje, setMensaje] = useState("");

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm({
    resolver: zodResolver(pizzaSchema),
  });

  const cargarDatos = async () => {
    try {
      const respuestaDashboard = await api.get("/Dashboard");
      const respuestaPizzas = await api.get("/Pizza");

      setDashboard(respuestaDashboard.data);
      setPizzas(respuestaPizzas.data);
    } catch {
      setMensaje("Error al cargar los datos del panel.");
    }
  };

  useEffect(() => {
    cargarDatos();
  }, []);

  const guardarPizza = async (data) => {
    try {
      setMensaje("");

      const pizzaData = {
        nombre: data.nombre,
        descripcion: data.descripcion,
        precio: data.precio,
        categoria: data.categoria,
        imagenUrl: data.imagenUrl || "",
      };

      if (pizzaEditando) {
        await api.put(`/Pizza/${pizzaEditando.id}`, pizzaData);
        setMensaje("Pizza actualizada correctamente.");
      } else {
        await api.post("/Pizza", pizzaData);
        setMensaje("Pizza creada correctamente.");
      }

      reset();
      setPizzaEditando(null);
      await cargarDatos();
    } catch {
      setMensaje("Ocurrió un error al guardar.");
    }
  };

  const editarPizza = (pizza) => {
    setPizzaEditando(pizza);

    reset({
      nombre: pizza.nombre,
      descripcion: pizza.descripcion,
      precio: pizza.precio,
      categoria: pizza.categoria,
      imagenUrl: pizza.imagenUrl || "",
    });
  };

  const eliminarPizza = async (id) => {
    try {
      await api.delete(`/Pizza/${id}`);
      setMensaje("Pizza eliminada correctamente.");
      await cargarDatos();
    } catch {
      setMensaje("Ocurrió un error al eliminar.");
    }
  };

  return (
    <main className="contenedor">
      <h1>Panel Admin</h1>

      {dashboard && (
        <section className="dashboard">
          <div>
            <h3>Total pizzas</h3>
            <p>{dashboard.totalPizzas}</p>
          </div>

          <div>
            <h3>Total usuarios</h3>
            <p>{dashboard.totalUsuarios}</p>
          </div>

          <div>
            <h3>Pizza más cara</h3>
            <p>${dashboard.pizzaMasCara}</p>
          </div>
        </section>
      )}

      <h2>{pizzaEditando ? "Editar pizza" : "Crear pizza"}</h2>

      <form onSubmit={handleSubmit(guardarPizza)} className="formulario">
        <label>Nombre</label>
        <input {...register("nombre")} />
        {errors.nombre && <p className="error">{errors.nombre.message}</p>}

        <label>Descripción</label>
        <input {...register("descripcion")} />
        {errors.descripcion && (
          <p className="error">{errors.descripcion.message}</p>
        )}

        <label>Precio</label>
        <input type="number" {...register("precio")} />
        {errors.precio && <p className="error">{errors.precio.message}</p>}

        <label>Categoría</label>
        <input {...register("categoria")} />
        {errors.categoria && (
          <p className="error">{errors.categoria.message}</p>
        )}

        <label>Imagen URL</label>
        <input placeholder="/img/cochina.jpg" {...register("imagenUrl")} />
        {errors.imagenUrl && (
          <p className="error">{errors.imagenUrl.message}</p>
        )}

        <button type="submit">{pizzaEditando ? "Actualizar" : "Crear"}</button>

        {pizzaEditando && (
          <button
            type="button"
            onClick={() => {
              setPizzaEditando(null);
              reset();
            }}
          >
            Cancelar edición
          </button>
        )}
      </form>

      {mensaje && <p>{mensaje}</p>}

      <h2>Pizzas cargadas</h2>

      <section className="grid">
        {pizzas.map((pizza) => (
          <article key={pizza.id} className="card">
            <img
              src={pizza.imagenUrl || "/img/default.jpg"}
              alt={pizza.nombre}
              className="imagen-pizza"
            />

            <h3>{pizza.nombre}</h3>
            <p>{pizza.categoria}</p>
            <p>${pizza.precio}</p>

            <button onClick={() => editarPizza(pizza)}>Editar</button>
            <button onClick={() => eliminarPizza(pizza.id)}>Eliminar</button>
          </article>
        ))}
      </section>
    </main>
  );
}

export default Admin;
