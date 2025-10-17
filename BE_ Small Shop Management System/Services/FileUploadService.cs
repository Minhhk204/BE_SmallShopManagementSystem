namespace BE__Small_Shop_Management_System.Services
{
   
        public class FileUploadService
        {
            private readonly IWebHostEnvironment _env;

            public FileUploadService(IWebHostEnvironment env)
            {
                _env = env;
            }

            public async Task<List<string>> UploadImagesAsync(IEnumerable<IFormFile> files, string folder)
            {
                var result = new List<string>();

                if (files == null || !files.Any())
                    return result;

                var allowedExt = new HashSet<string> { ".jpg", ".jpeg", ".png", ".webp" };
                long maxBytes = 5 * 1024 * 1024; // 5MB

                // Đường dẫn thư mục lưu ảnh (vd: wwwroot/images/products)
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images", folder);
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                foreach (var file in files)
                {
                    var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                    if (!allowedExt.Contains(ext))
                        throw new InvalidOperationException($"File '{file.FileName}' không hợp lệ (chỉ chấp nhận JPG, PNG, WEBP).");

                    if (file.Length == 0 || file.Length > maxBytes)
                        throw new InvalidOperationException($"File '{file.FileName}' quá lớn (tối đa 5MB).");

                    var fileName = Guid.NewGuid().ToString() + ext;
                    var savePath = Path.Combine(uploadsFolder, fileName);

                    // Lưu file lên server
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    //Trả về đường dẫn tương đối để lưu DB
                    result.Add($"/images/{folder}/{fileName}");
                }

                return result;
            }
        }
    }

