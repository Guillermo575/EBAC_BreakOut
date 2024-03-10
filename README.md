# EBAC_BreakOut - Tareas Por hacer
	
*	Añadir
	-	Powerups:
		*	Cuando rompas los bloques premio este dejara caer un objeto que el jugador debera de tocar
    		*	Al tocarlo el objeto se destruira pero activara un evento
    			-	Se mostrara un mensaje en pantalla y un icono en el HUD
			-	Algún efecto aleatorio que durara hasta que el nivel finalice o pierdas una vida
     				*	Multibola
					-	Instanciar una bola nueva con los mismos listeners
    					-	Agregar un contador de bolas en el administrador de vidas
    					-	Ajustar que se perdera una vida cuando ya no existan bolas 
    				*	Bola mas grande (hara mas daño)
    					-	Solo aplicara con la primera bola
    					-	Agregar en la bola una variable de daño
    					-	Escala total * 2
    					-	Añadir en la mecanica de rebote que si la resistencia despues de romperse da igual o menor de -1 no hara que la bola rebote sino que se ira de largo
    				*	Paddle mas largo
    					-	Alargar horizontalmente el paddle
    				*	Terremoto
    					-	Todos los bloques perderan 1 punto de resistencia
    	-	Bloque Explosivo
       		*	Al destruir el bloque activara una animacion de una explosión
        	*	Detectara en un radio de N distancia los bloques de esa area
        	*	Se le restara 2 puntos de resistencia a cada bloque golpeado

*	Crear Mejorar
	-	Imagenes para el skybox
	-	Cambiar estilo botones del menu
	-	Adornar pantalla de inicio
		*	Poner titulo en forma de logotipo
		*	Poner pelotas rebotando en la pantalla
		
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
