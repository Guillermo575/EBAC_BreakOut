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

*	Revisar
	-	Movimiento del paddle
		-	Cuando el paddle le pegue a la pelota y este este debajo de el, moverlo hacia arriba
	-	Velocidad del paddle
		*	Se cambiara en opciones de velocidad de la bola por velocidad del paddle
    	-	Administrador de Musica y Sonido
		*	Musica
			-	Game Over
				*	Detener BGM y reproducir el sonido
			-	Level Clear
				*	Detener BGM y reproducir el sonido
    	
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
