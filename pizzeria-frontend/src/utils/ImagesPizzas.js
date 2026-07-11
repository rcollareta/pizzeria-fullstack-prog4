function obtenerImagenPizza(nombre) {
  const nombrePizza = nombre.toLowerCase();

  if (nombrePizza.includes("muzzarella")) {
    return "/img/muzzarela.jpg";
  }

  if (nombrePizza.includes("napolitana")) {
    return "/img/napolitana.jpg";
  }

  if (nombrePizza.includes("especial")) {
    return "/img/especial.png";
  }

  // return "/img/default.jpg";
}

export default obtenerImagenPizza;
