# WhatsappApi
# Whatsapp API C#


# Tabla de Contenidos 

 - [Creacion de cuenta Meta](#Creacion-Cuenta-Meta-y-App-de-WhatsApp)
 - [Creacion de Templates](#Creacion-de-Templates)
 - [Testeo de Templates](#Testeo-de-Templates)
 - [Como usar la aplicacion C#](#Como-usar-la-aplicacion-C#)
 



## Creacion Cuenta Meta y App de WhatsApp


Primero que todo, hay que registrar una cuenta de Meta en el siguiente link: [Facebook Bussiness](https://business.facebook.com/), ya sea asociando una cuenta de facebook ya creada o creando una nueva.
Una vez registrada la cuenta, hay que crear un bussiness account con los datos de la empresa
![1](https://i.imgur.com/xgjekir.png)
Ya subidos los datos se pedira confirmar el correo ingresado.
Elegimos la cuenta creada en la seccion superior izquierda, y luego nos vamos a la pestana de accounts/apps y anadimos una nueva![](https://i.imgur.com/Sw54SIa.png)
Nos llevara otro menu en donde elegiran la opcion de bussiness y llenaran con los datos acordes.
Creada la app se nos abrira un menu para agregar productos a la app, en donde apretaran el set up de WhatsApp y luego al boton **Start using the API**.

Se desplegara este menu:
![enter image description here](https://i.imgur.com/gc0UTaU.png)
En donde se podra comprobar si la app funciona agregando un numero y usando el boton de **Send message**.
Para este punto la app solo puede enviar mensajes a numeros registrados previamente, lo cual se arregla agregando un numero de telefono en el paso 5 el cual desplegara un menu que tendran que rellenar con los datos acordes
![enter image description here](https://i.imgur.com/Ka9TrQt.png)


## Creacion de Templates
La API de whatsapp funciona con templates, las cuales contienen unas variables para personalizar el mensaje especifico al usuario.
Por ejemplo, el boton de **Send message** de la seccion anterior usa la plantilla *hello_world*, la cual no tiene variables.
Para crear templates, hay que dirigirse al link indicado en el paso dos.
![enter image description here](https://i.imgur.com/4cN8ikt.png)

Una vez en el menu de templates, podremos ver todas las plantillas de muestra, donde podremos filtrarlas por categoria y lenguaje. Para crear una vamos al boton **Create template**, en donde hay que seleccionar la categoria, el nombre y el lenguaje.
![enter image description here](https://i.imgur.com/oJdqlO6.png)
En este menu podremos editar las diferentes variables del mensaje, ya sea el header, body, footer y los botones.
una vez terminado el mensaje, vamos a agregar un sample para que la revision de la plantilla sea mas rapida.
> **Disclaimer:** Nunca logre que me aceptaran una plantilla, lo intente reiteradas veces pero siempre me las rechazaron incluso con ejemplos copiados de youtube y demas. Yo sospecho que era por la calidad de la cuenta que tenia, ya que no tenia nada verificado ya que realmente todo estaba a mi nombre en vez de una empresa.


## Testeo de Templates
Para enviar los mensajes en la aplicacion de C#, se debe subir un archivo JSON, el cual tiene que estar estructurado de una forma especifica para que funcione. Dicho esto, pueden usar [Postman](https://www.postman.com/downloads/postman-agent/) para comprobar esto.
Una vez abierto Postman, hay que iniciar sesion y crear una nueva HTTP Request
![enter image description here](https://i.imgur.com/d5aiQNf.png)
Primero, hay que registrar el access token en la seccion de headers![enter image description here](https://i.imgur.com/MnuE626.png)
Este se compone de la key "Authorization" la cual esta acompanada de un value compuesto de la palabra Bearer + Access Token![](https://i.imgur.com/attZDCo.png)
Si bien este solo dura 24 horas, se pueden crear uno permantente siguiendo el siguiente [tutorial](https://youtu.be/PFf6GB2E1Ao) 
>Disclaimer: no suban el access token nunca a ningun repositorio de github ni nada parecido porque lo caducan enseguida por seguridad.
>
Luego, vamos al Body, en donde colocamos la seccion de *raw* y cambiamos la request por un Post en vez de un Get.
Una vez hecho esto, copiamos y pegamos el siguiente link:
![enter image description here](https://i.imgur.com/RQ4pUdq.png)
![](https://i.imgur.com/kzLYo8S.png)
El contenido del body depende del template que estemos usando y las diferentes variables que contienen, por ejemplo este es el body del template *hello_world*:
```
{
	"messaging_product":  "whatsapp",
		"to":  "PHONENUMBER",
		"type":  "template",
		"template":  {
			"name":  "hello_world",
			"language":  {
			"code":  "en_US"
			}
		}
}
```
Este es otro ejemplo para el template *sample_purchase_feedback*
```
{
	"messaging_product":  "whatsapp",
	"to":  "PHONENUMBER",
	"type":  "template",
	"template":  {
		"name":  "sample_purchase_feedback",
		"language":  {
			"code":  "es"
		},
		"components":  [
			{
				"type":  "header",
				"parameters":  [
					{
						"type":  "image",
						"image":  {
							"link":  "VARIABLE0"
						}
					}
				]
			},
			{
				"type":  "body",
				"parameters":  [
					{	
						"type":  "text",
						"text":  "VARIABLE1"
					}
				]
			}
		]
	}
}
```
Si bien se ve bien complejo, en general se lleva una estructura bien intuitiva a la hora de ver como se definen las variables.
En esta [pagina](https://developers.facebook.com/docs/whatsapp/on-premises/reference/messages) se explica de manera confusa y poca intuitiva como crear los mensajes
> Si es necesario, no tengo problemas en hacerles yo el JSON cuando creen un template :)

Cambiando el texto de la parte que dice *PHONENUMBER* a un numero real y apretando SEND, deberia funcionar, por el contrario, probablemente sea un error en las variables, ya sea porque los links no tienen un formato correcto o no llevan un archivo o imagen valido.

# Como usar la aplicacion C#
Antes que todo, hay que crear un archivo con el nombre **template.json**, este contendra el body del template con unos ligeros cambios que describire a continuacion:

 1. Al igual que como se ve en el ejemplo, el numero y las variables tienen que tener el formato *PHONENUMBER*, *VARIABLE0*, *VARIABLE1*,*VARIABLE2* y asi en adelante
 2. Hay que eliminar las identaciones y dejarlo todo en una sola linea
 Este seria un ejemplo del *sample_purchase_feedback*:
 ```
{"messaging_product": "whatsapp","to": "PHONENUMBER","type": "template","template": {"name": "sample_purchase_feedback","language": {"code": "es"},"components": [{"type": "header","parameters": [{"type": "image","image": {"link": "VARIABLE0"}}]},{"type": "body","parameters": [{"type": "text","text": "VARIABLE1"}]}]}}
```
Una vez ya creado el archivo, hay que guardarlo en la siguiente ruta de la aplicacion:
```
...\WhatsappApi\WhatsappApi\bin\Debug\n
