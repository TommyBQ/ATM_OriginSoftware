# ATM_OriginSoftware 💳 - Challenge .NET

## REQUISITOS
- Visual Studio 2022
- Visual Studio Code
- SQL Server Managment 18
- Node.js
- Angular CLI 14.1.3

## PARA CREAR LA BD
1. Abra SQL Server Managment Studio
2. Arrastre, dentro de SQL, el archivo BD_ATMOriginSoftware.sql
3. Para ejecutar la query apriete F5
4. La BD debería estar creada!

## PARA EJECUTAR EL BACKEND
1. Una vez clonado el repositorio, ingresar a la carpeta llamada *ATM_OriginSoftwareAPI* y abrir el archivo **ATM_OriginSoftwareAPI.sln** con Visual Studio 2022.
2. Para que el backend y la BD puedan comunicarse, dirigirse a *Web -> appsettings.json* y reemplazar en la *ConnectionString* donde dice **NOMBRE_DEL_SERVIDOR** por el nombre de su servidor donde se encuentra la BD antes creada.
3. Guarde los cambios del archivo con Ctrl+S.
4. Para inicializar el backend, hacer click en el botón de play donde dice *ATM_OriginSoftwareAPI*. Realizado esto, ya estaría funcionando el backend de la aplicación y se abriría una ventana con Swagger.


## PARA EJECUTAR EL FRONTEND
1. Dirigirse a la carpeta *ATM_OriginSoftwareAPI* y entrar en la carpeta llamada *atm-web-angular* y abrir esta ultima carpeta con VS Code.
2. Dentro de VS Code, abrir una nueva terminal y ejecutar el comando `npm install`.
3. Luego de que termine de instalar las dependencias, ejecutar el comando `ng serve --o`.
4. Se abrirá una ventana en el navegador con la aplicación funcionando.


## DATOS PARA PROBAR
Dentro de la BD hay 3 tarjetas de ejemplo: 

- Tarjeta 1:
    - N° Tarjeta: 1111111111111111
    - PIN: 1111
    - Balance: 1111
    - EstaBloqueada: false

- Tarjeta 2:
    - N° Tarjeta: 1234567891234567
    - PIN: 1234
    - Balance: 150000
    - EstaBloqueada: false

- Tarjeta 3:
    - N° Tarjeta: 1111222233334444
    - PIN: 1245
    - Balance: 25
    - EstaBloqueada: true