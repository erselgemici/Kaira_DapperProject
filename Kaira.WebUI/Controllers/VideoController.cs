using Kaira.WebUI.DTOs.VideoDtos;
using Kaira.WebUI.Repositories.VideoRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Kaira.WebUI.Controllers
{
    public class VideoController(IVideoRepository _videoRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var videos = await _videoRepository.GetAllAsync();
            return View(videos);
        }
        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateVideoDto videoDto)
        {
            await _videoRepository.CreateAsync(videoDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteVideo(int id)
        {
            await _videoRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateVideo(int id)
        {
            var video = await _videoRepository.GetByIdAsync(id);
            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(UpdateVideoDto videoDto)
        {
            await _videoRepository.UpdateAsync(videoDto);
            return RedirectToAction("Index");
        }
    }
}
