namespace Kaira.WebUI.DTOs.AiInteractionDtos
{
    public class ResultAiInteractionDto
    {
        public int InteractionId { get; set; }
        public string UserQuery { get; set; }
        public string AiResponse { get; set; }
        public DateTime InteractionDate { get; set; }
    }
}
