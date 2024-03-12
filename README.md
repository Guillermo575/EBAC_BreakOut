# EBAC_BreakOut - Tareas Por hacer
	
*	Añadir
	-	Powerups:
		*	Cuando rompas los bloques premio este dejara caer un objeto que el jugador debera de tocar
	    		-	Al tocarlo el objeto se destruira pero activara un evento Y se mostrara un mensaje en pantalla y un icono en el HUD
   				*	Crear prefab llamado PowerupPill con un tag propio
   				*	En el bloque premio tendra una clave que indicara el powerup, al instanciar el prefab colocara esa clave
   				*	El prefab ira hacia la direccion del suelo verticalmente solamente
   					-	Si lo toca el suelo se destruira
   					-	Si lo toca el jugador se destruira, tomara la clave del objeto y llamara al administrador de powerups
			-	Algún efecto aleatorio que durara hasta que el nivel finalice o pierdas una vida
				*	Paddle mas largo
					-	Alargar horizontalmente el paddle
					-	Durara hasta que el nivel finalice o pierdas una vida
	-	Bloque Explosivo
		*	Al destruir el bloque activara una animacion de una explosión
    			-	Se añadira un efecto de particulas
		*	Detectara en un radio de N distancia los bloques de esa area
		*	Se le restara 2 puntos de resistencia a cada bloque golpeado

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
	-	Ajustar valores de opciones de Scriptable Object en la bola
		*	Dificultad
			-	Numero de Vidas
			-	Tamaño del paddle
			-	Velocidad del paddle
			-	Timer de lanzamiento de bola
			-	Puntos ganados
			
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
