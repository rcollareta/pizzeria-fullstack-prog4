import { Link } from "wouter";

function Home() {
  return (
    <main className="home">
      <section className="hero">
        <div className="hero-contenido">
          <span className="etiqueta">🍕 Proyecto Fullstack</span>

          <h1>Pizzería 5G</h1>

          <p>
            Las mejores pizzas artesanales, con un sistema moderno hecho en
            React y ASP.NET Core.
          </p>

          <div className="hero-botones">
            <Link href="/elementos">
              <button>Ver menú</button>
            </Link>

            <Link href="/login">
              <button className="boton-secundario">Ingresar</button>
            </Link>
          </div>
        </div>
      </section>

      <section className="beneficios">
        <article>
          <h3>🔥 Horno caliente</h3>
          <p>Pizzas listas para disfrutar.</p>
        </article>

        <article>
          <h3>🧀 Ingredientes frescos</h3>
          <p>Calidad en cada porción.</p>
        </article>

        <article>
          <h3>⚡ Sistema rápido</h3>
          <p>Menú digital con panel admin.</p>
        </article>
      </section>
    </main>
  );
}

export default Home;
