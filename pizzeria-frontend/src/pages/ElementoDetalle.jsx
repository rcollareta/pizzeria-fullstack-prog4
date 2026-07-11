import { useEffect, useState } from "react";
import { Link, useParams } from "wouter";
import api from "../api/api";

function ElementoDetalle() {
  const params = useParams();
  const [pizza, setPizza] = useState(null);
  const [error, setError] = useState("");

  useEffect(() => {
    const cargarPizza = async () => {
      try {
        const respuesta = await api.get(`/Pizza/${params.id}`);
        setPizza(respuesta.data);
      } catch {
        setError("No se encontró la pizza.");
      }
    };

    cargarPizza();
  }, [params.id]);

  if (error) {
    return (
      <main className="contenedor">
        <p className="error">{error}</p>

        <Link href="/elementos">
          <button>Volver</button>
        </Link>
      </main>
    );
  }

  if (!pizza) {
    return <p className="contenedor">Cargando detalle...</p>;
  }

  return (
    <main className="contenedor">
      <h1>{pizza.nombre}</h1>

      <img
        src={pizza.imagenUrl || "/img/default.jpg"}
        alt={pizza.nombre}
        className="imagen-detalle"
      />

      <p>
        <strong>Categoría:</strong> {pizza.categoria}
      </p>

      <p>
        <strong>Descripción:</strong> {pizza.descripcion}
      </p>

      <p>
        <strong>Precio:</strong> ${pizza.precio}
      </p>

      <Link href="/elementos">
        <button>Volver al menú</button>
      </Link>
    </main>
  );
}

export default ElementoDetalle;
