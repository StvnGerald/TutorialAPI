using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TutorialAPI;

namespace TutorialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa 
            {
                Nama = new Nama { Depan = "Steven", Belakang = "Gerald" },
                Nim = 103022300155,
                Fakultas = "Informatika"
            }
        };

        // GET: api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return Ok(daftarMahasiswa);
        }

        // POST: api/mahasiswa
        [HttpPost]
        public ActionResult<IEnumerable<Mahasiswa>> Post([FromBody] Mahasiswa mahasiswa)
        {
            if (mahasiswa == null)
            {
                return BadRequest(new { message = "Data mahasiswa tidak valid." });
            }

            daftarMahasiswa.Add(mahasiswa);
            return Ok(daftarMahasiswa);
        }

        // GET: api/mahasiswa/{id}
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> GetById(int id)
        {
            if (id < 0 || id >= daftarMahasiswa.Count)
                return NotFound(new { message = "Mahasiswa tidak ditemukan." });

            return Ok(daftarMahasiswa[id]);
        }

        // DELETE: api/mahasiswa/{id}
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Mahasiswa>> Delete(int id)
        {
            if (id < 0 || id >= daftarMahasiswa.Count)
                return NotFound(new { message = "Mahasiswa tidak ditemukan." });

            daftarMahasiswa.RemoveAt(id);
            return Ok(daftarMahasiswa);
        }
    }
}
