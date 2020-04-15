# unity-panda-invasion
Juego en 2d tower game
# Ideas para implementar en el juego
- Cuando arranca el juego, los enemigos empiezan a ir hacia el castillo, y el jugador tiene que empezar a comprar torretas para defender, pero el inicio no hay azucar, si no esta a piñon, pero conviene que este en otro lugar, 
que sea una variable que se pueda configurar 
- Hacer que antes de entrar la primera oleada de enemigos, hacer esperar x tiempo a que llege la primera oleada, se puede mostrar un contador de tiempo restante para que el jugador le de tiempo a plantar sus primeras torretas
- Mostrar oleada actual y total de oleadas
- Cuantas mas oleadas llevas mas ha ido avanzado el sistema y mas azucar deberia de ganar el jugador
- Cuando acaba una olea se lle de al usuario X de azucar por terminar la oleada, un bonus extra
- Modificar el codigo para usar el patron singleton en algunos scripts
- Si queremos exportar el juego a movil hay que modificar el input del raton, por el dedo
- Cuando arrancamos el juego, mostrar iformacion de las torretas(ventas, subidas)...
- Cuando se gana o se pierde azucar, sacar un mensaje que diga +5 o -5...
- Añadir variedad de enemigos
- Terminar menu principal -> settingss
- Final de la oleada final, un unico enemigo enorme

# Ideas para implementar en el juego 2

- Torretas
	- Cambiar logica de cada torreta
		- Torreta puede disparar al mas devil o al mas fuerte o igual
		- Disparar a el que esta mas lejos/cerca
	- Añadir vida
	- Se puede desgastar y cada vez que disparar quitarle vida para destruirla y que haga mas daño
		- Añadir nuevo boton para repararla
	- Añadir torreta de recuperación
		
- Projectil
	- Projectil que congele
	- Projectil que queme/envenene
	- Projectil explosivos
	- Projectil daño critico
		- Projectil daño critico solo a los que no son boss
	- Projectil puede ser abstacto y hacer subclases con tipos como poisonScript : projectilScript...
	- Añadir animaciones cuando hacen daño

- Enemies
	- Puede ser abstacto y puede haber subclases de enemigos
	- Puede haber enemigos que exploten y hacer daño a las torretas cercanas
	- Añadir barra de vida

- Enemy hechizero
	- Cada x segundos puede invocar a x enemigos mas

- Enemigo multifase
	- puede tener 3 niveles
	- en cada fase puede hacer algo diferente

- Levels
	- Añadir mas niveles al juego	
	- Hacer un mapa de todos los niveles
	- Que se guarden los niveles

- Oleadas
	- Sistema de rondas que se pueda configurar desde el editor
	- Spawning system
		- Wave 1
			- Type enemy 1	
				- 12
			- Type enemy 2
				- 7
			- Type enemy 3
				- 3
		- Wave 2
			- Type enemy 1  
                                - 16
                        - Type enemy 2
                                - 10
                        - Type enemy 3
                                - 5
