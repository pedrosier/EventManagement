using System;
using EventManagement.Domain.Entities;

namespace EventManagement.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Speaker Examples
            Console.WriteLine("=== Speaker Examples ===");

            // Criar palestrante válido
            var speakerValid = new Speaker(1, "Pedro Classhero", "pedroclasshero@email.com");
            Console.WriteLine(speakerValid);

            // Tentar criar com dados inválidos
            try
            {
                var speakerInvalidId = new Speaker(0, "Nome", "email@email.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção esperada: {ex.Message}");
            }

            try
            {
                var speakerInvalidName = new Speaker(1, " ", "email@email.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção esperada: {ex.Message}");
            }

            try
            {
                var speakerInvalidEmail = new Speaker(1, "Nome", "invalidemail");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção esperada: {ex.Message}");
            }

            // Demonstrar SetBiography
            speakerValid.SetBiography("Biografia válida");
            Console.WriteLine($"Biografia: {speakerValid.Biography}");
            speakerValid.SetBiography(null);
            Console.WriteLine($"Biografia após null: {speakerValid.Biography}");
            speakerValid.SetBiography("   ");
            Console.WriteLine($"Biografia após espaços: {speakerValid.Biography}");

            // Company e LinkedInProfile com null
            speakerValid.Company = null;
            Console.WriteLine($"Company: '{speakerValid.Company}'");
            speakerValid.LinkedInProfile = null;
            Console.WriteLine($"LinkedInProfile: '{speakerValid.LinkedInProfile}'");

            #endregion

            #region Venue Examples
            Console.WriteLine("\n=== Venue Examples ===");

            // Criar local válido
            var venueValid = new Venue(1, "Centro de Convenções", "Av. Principal, 100", 500);
            Console.WriteLine(venueValid);

            // Demonstrar Venue.Default
            Console.WriteLine($"Default Venue: {Venue.Default}");

            // SetDescription
            venueValid.SetDescription("Descrição válida");
            Console.WriteLine($"Descrição: {venueValid.Description}");
            venueValid.SetDescription(null);
            Console.WriteLine($"Descrição após null: {venueValid.Description}");

            // ParkingInfo com null
            venueValid.ParkingInfo = null;
            Console.WriteLine($"ParkingInfo: '{venueValid.ParkingInfo}'");

            #endregion

            #region Event Examples
            Console.WriteLine("\n=== Event Examples ===");

            // Criar evento válido
            var eventValid = new Event(1, ".NET Conference", new DateTime(2025, 12, 15), TimeSpan.FromHours(8));
            Console.WriteLine(eventValid);

            // Lazy loading de Venue
            Console.WriteLine($"Venue (lazy): {eventValid.Venue}");

            // SetEventCode
            eventValid.SetEventCode("NETCONF");
            Console.WriteLine($"EventCode: {eventValid.EventCode}");

            // Tentar SetEventCode null
            try
            {
                eventValid.SetEventCode(null!);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção esperada: {ex.Message}");
            }

            // Atribuir palestrante
            eventValid.AssignMainSpeaker(speakerValid);
            Console.WriteLine($"MainSpeaker: {eventValid.MainSpeaker?.FullName}");

            // Requirements e Notes com null
            eventValid.Requirements = null;
            Console.WriteLine($"Requirements: '{eventValid.Requirements}'");
            eventValid.Notes = null;
            Console.WriteLine($"Notes: '{eventValid.Notes}'");

            #endregion

            #region Complete Scenario
            Console.WriteLine("\n=== Complete Scenario ===");

            // Criar palestrante
            var speaker = new Speaker(1, "Pedro Classhero", "pedroclasshero@email.com");
            speaker.SetBiography("Especialista em C# com 10 anos de experiência");
            speaker.Company = "Tech Corp";

            // Criar local
            var venue = new Venue(1, "Centro de Convenções", "Av. Principal, 100", 500);
            venue.SetDescription("Moderno centro com infraestrutura completa");

            // Criar evento
            var evento = new Event(1, ".NET Conference 2025", new DateTime(2025, 12, 15), TimeSpan.FromHours(8));
            evento.SetEventCode("NETCONF2025");
            evento.SetDescription("Conferência anual sobre tecnologias .NET");
            evento.AssignMainSpeaker(speaker);

            // Exibir informações
            Console.WriteLine(evento);
            Console.WriteLine($"Local: {evento.Venue}");
            Console.WriteLine($"Palestrante: {evento.MainSpeaker?.FullName ?? "A definir"}");

            #endregion
        }
    }
}