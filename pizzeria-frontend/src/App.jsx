import { lazy, Suspense, useEffect } from "react";
import { Route, Switch, useLocation } from "wouter";
import Navbar from "./components/Navbar";
import useAuthStore from "./store/authStore";
import "./index.css";

import Home from "./pages/Home";
import Login from "./pages/Login";
import Elementos from "./pages/Elementos";

const ElementoDetalle = lazy(() => import("./pages/ElementoDetalle"));
const Admin = lazy(() => import("./pages/Admin"));

function RutaAdmin() {
  const usuario = useAuthStore((state) => state.usuario);
  const [, setLocation] = useLocation();

  useEffect(() => {
    if (!usuario || usuario.rol !== "Admin") {
      setLocation("/login");
    }
  }, [usuario, setLocation]);

  if (!usuario || usuario.rol !== "Admin") {
    return <p className="contenedor">Redirigiendo...</p>;
  }

  return <Admin />;
}

function App() {
  return (
    <>
      <Navbar />

      <Suspense fallback={<p className="contenedor">Cargando...</p>}>
        <Switch>
          <Route path="/" component={Home} />
          <Route path="/login" component={Login} />
          <Route path="/elementos" component={Elementos} />
          <Route path="/elementos/:id" component={ElementoDetalle} />
          <Route path="/admin" component={RutaAdmin} />

          <Route>
            <p className="contenedor">Página no encontrada</p>
          </Route>
        </Switch>
      </Suspense>
    </>
  );
}

export default App;