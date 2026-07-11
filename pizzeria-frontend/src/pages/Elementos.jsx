import { useEffect, useState } from "react";
import { Link } from "wouter";
import api from "../api/api";

function Elementos() {
  const [pizzas, setPizzas] = useState([]);
  const [busqueda, setBusqueda] = useState("");
  const [categoria, setCategoria] = useState("");
  const [cargando, setCargando] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    const cargarPizzas = async () => {
      try {
        const respuesta = await api.get("/Pizza");
        console.log("Pizzas recibidas:", respuesta.data);
        setPizzas(respuesta.data);
      } catch (error) {
        console.log("Error al cargar pizzas:", error);
        setError("No se pudieron cargar las pizzas.");
      } finally {
        setCargando(false);
      }
    };

    cargarPizzas();
  }, []);

  const pizzasFiltradas = pizzas.filter((pizza) => {
    const coincideNombre = pizza.nombre
      .toLowerCase()
      .includes(busqueda.toLowerCase());

    const coincideCategoria =
      categoria === "" || pizza.categoria === categoria;

    return coincideNombre && coincideCategoria;
  });

  const categorias = [...new Set(pizzas.map((pizza) => pizza.categoria))];

  return (
    <main className="contenedor">
      <h1>Menú de pizzas</h1>

      <div className="filtros">
        <input
          placeholder="Buscar por nombre..."
          value={busqueda}
          onChange={(e) => setBusqueda(e.target.value)}
        />

        <select
          value={categoria}
          onChange={(e) => setCategoria(e.target.value)}
        >
          <option value="">Todas las categorías</option>

          {categorias.map((cat) => (
            <option key={cat} value={cat}>
              {cat}
            </option>
          ))}
        </select>
      </div>

      {cargando && <p>Cargando pizzas...</p>}
      {error && <p className="error">{error}</p>}

      {!cargando && pizzasFiltradas.length === 0 && !error && (
        <p>No hay pizzas para mostrar.</p>
      )}

      <section className="grid">
        {pizzasFiltradas.map((pizza) => (
          <article key={pizza.id} className="card">
            <img
              src={pizza.imagenUrl || "/img/default.jpg"}
              alt={pizza.nombre}
              className="imagen-pizza"
            />

            <h2>{pizza.nombre}</h2>
            <p>{pizza.categoria}</p>
            <p>${pizza.precio}</p>

            <Link href={`/elementos/${pizza.id}`}>
              <button>Ver detalle</button>
            </Link>
          </article>
        ))}
      </section>
    </main>
  );
}

export default Elementos;