# EBAC_BreakOut - Tareas Por hacer
*	Revisar
	-	Cuando aumente el tamaño de la bola no se salga del paddle y ver su tamaño
	-	Revisar que el borde de la escala no se salga del marco
	-	Revisar color de las letras del HUD
*	Añadir
	-	Powerups:
		*	Cuando rompas los bloques premio activara el powerup
	-	Bloque Explosivo
		*	Al destruir el bloque activara una animacion de una explosión
			-	Se añadira un efecto de particulas expansivo
		*	Detectara en un radio de N distancia los bloques de esa area
		*	Se le restara 2 puntos de resistencia a cada bloque dentro de dicha area

*	Crear Mejorar
	-	Cambiar estilo botones del menu
		*	Se desplegara el menu al oprimir escape
    		*	Se ocultara el botón de Menu al abrirse dicho menu pero al oprimir escape se reanudara la partida
	-	Adornar pantalla de inicio
		*	Poner titulo en forma de logotipo
		*	Poner pelotas rebotando en la pantalla  
	-	Imagenes para el skybox

*	Tarea
	-	Crear mas niveles
		*	Fijar bordes independientemente de la camara
	-	Poner un sistema de puntuación individual por cada nivel
	-	Sistema de dificultad
		*	Atributos (se guardara en un scriptable object SO_Dificultad)
			-	Numero de Vidas (Administrador_Vidas)
			-	Tamaño del paddle (Jugador)
			-	Velocidad de la bola (Bola)
			-	Timer de lanzamiento de bola (Bola)
			-	multiplo de Puntos ganados (Bloque)
			-	Velocidad y escala de bloque premio (Caja PowerUp)
		*	Al iniciar una partida nueva se tomara la dificultad seleccionada en Opciones, agarrara la dificultad en el SO_Dificultad y lo guardara en el GameManager
    		*	Los scripts tomaran la dificultad seleccionada 

*	Planes a futuro:
  	-	Se pensara en desarrollarlo una vez que se entregue el proyecto de la tarea
  	-	Objetivo del juego:
		*	En vez de tratarse sobre destruir bloques sera sobre eliminar enemigos
		*	Los enemigos tienen puntos de vida con varias capacidades
			-	Se podran mover
			-	Se teletransportaran
			-	Crearan bloques nuevos
			-	Atacaran tanto al jugador como a la bola en si (sistema de maldiciones)
	-	Sistema de maldiciones
		*	Seran eventos negativos que afectaran al jugador
			-	El paddle dejara de moverse por N segundos
			-	La bola se volvera invisible hasta que la golpees con el paddle
			-	Bola mas rapida
			-	Se restauraran algunos bloques
	-	Variedad de niveles
		*	Los niveles estaran agrupados por mundos para una mejor organizacion 	
