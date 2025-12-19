namespace Kaira.WebUI.DTOs.MainSliderDtos
{
    public class CreateMainSliderDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public bool IsActive { get; set; }
    }
}
