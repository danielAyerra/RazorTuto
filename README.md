# RazorTuto
RazorTutorial with some modifications as I saw fit.

## Multiple Databases
This project have different Database Contexts because two databases are used, depending on the environment. For Development, SqLite is used and for Production MariaDb is used.
The very same context could have been used. Actually, there is no reason to make two Contexts in this case. However, and trying to be as real as posible, SqLite is no good for production, except maybe to keep Cookie/Session info.

TODO: Securize the MariaDb Connection String and extract it from appSettings.Production.json.

### Entity framework
Since Entity Framework is being used, the job is way easier with the migrations and totally in synch with the Model. Make sure to learn Entity Framework!!

## Localization
I am Spanish, so I set the project to es-ES.
TODO: Whenever writing a decimal number, when introducing a dot, convert it to a comma instead of writing thousand.

## Validation
With Localization, some scripts have been added to the UI so that Validation at the front works properly.

## GUI
TODO: Bootstrap is great and responsive... However, I would like to give it my touch :)
