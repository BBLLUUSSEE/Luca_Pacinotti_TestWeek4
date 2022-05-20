using GestioneSpese;

bool quit = false;
do
{
    Console.WriteLine($"===========MENU==========\n");
    Console.WriteLine("[1] - Aggiungi una spesa\n");
    Console.WriteLine("[2] - Approva una spesa\n");
    Console.WriteLine("[3] - Elimina una spesa\n");
    Console.WriteLine("[4] - Elenco spese approvate\n");
    Console.WriteLine("[5] - Elenco delle Spese di uno specifico Utente\n");
    Console.WriteLine("[6] - Il totale delle Spese per Categoria\n");
    Console.WriteLine("[q] - QUIT\n");

    string scelta = Console.ReadLine();
    switch (scelta)
    {
        case "1":
            Gestione.InsertSpesa();
            break;
        case "2":
            Gestione.UpdateSpesa();
            break;
        case "3":
            Gestione.DeleteSpesa();
            break;
        case "4":
            GestioneDisconnected.ShowAllApproveSpesa();
            break;
        case "5":
            Gestione.ShowSpecificPersonSpesa();
            break;
        case "6":
            Gestione.TotalSpese();
            break;
        case "q":
            quit = true;
            break;
        default:
            Console.WriteLine("Comando sconosciuto");
            break;

    }
} while (!quit);