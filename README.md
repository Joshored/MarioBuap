# Proyecto: Videojuego 2D estilo Mario Bros en Unity

Este proyecto consiste en un juego de plataformas en 2D desarrollado con Unity y C#, inspirado en el clásico Super Mario Bros. El juego incluye elementos básicos 
como movimiento del jugador, enemigos, monedas, tuberías, plataformas, y power-ups.


# Jugador

- Controlado con teclado (`A`, `D` para moverse, `Espacio` para saltar).
- Usa `Rigidbody2D` y `Animator` para física y animaciones.
- Puede eliminar enemigos al pisarlos.
- Interactúa con monedas, tuberías y hongos.
- Al recoger un hongo, el personaje crece (power-up).


# Enemigos
- Es este proyecto por ahora solo se incluyo a un enemigo siendo este el goomba sin embargo se
  podria agreagar mas enemigos a futuro
  
# Goomba
- Camina automáticamente en una dirección.
- Usa `Raycast` para detectar bordes de plataformas.
- Cambia de dirección al llegar a un borde.
- Muere si el jugador lo pisa desde arriba.
- Daña al jugador si lo toca de frente.

### Koopa
- Se comporta similar al Goomba.
- Puede entrar en caparazón cuando es golpeado.


# Monedas

- Repartidas por todo el escenario.
- Se recogen al tocarlas.
- Suman puntos 


# Tuberías

- Están integradas en el escenario.
- Funcionan como obstáculos o decoraciones.
- Pueden implementarse como acceso a otras zonas o niveles en versiones futuras.


#Escenario

- Construido con `Tilemap`
- Compuesto por plataformas, paredes, suelo y obstáculos.
- Incluye colisiones físicas (`BoxCollider2D`) para permitir saltos y desplazamiento.
- Fondo con imagen estática o desplazamiento de cámara (`CameraFollow`).

---

# Power-Up: Hongo

- Aparece en ciertos bloques.
- Al ser recogido, el jugador cambia de escala para simular que crece.
- Mejora las habilidades del jugador (resiste un golpe sin morir, por ejemplo).
- Animado y con sonido al recogerlo.

---

# Música y Sonidos

- Música de fondo reproducida en bucle con `AudioSource`.
- Todos los sonidos están en formato `.mp3`.


# Cómo Jugar

1. Ejecuta la escena principal en Unity.
2. Usa las teclas `A` y `D` para moverte, `Espacio` para saltar.
3. Pisa enemigos para eliminarlos.
4. Recoge monedas y hongos.
5. Explora el escenario sin caer ni chocar con enemigos de frente.

![Captura de pantalla 2025-05-21 101154](https://github.com/user-attachments/assets/c12bab63-c724-449e-bcbc-7ce42b7a5d54)

