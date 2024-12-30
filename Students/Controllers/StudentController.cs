using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Students.DTO;
using Students.Model;
using Students.Repository.IRepository;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository stdRepo;
        private readonly IMapper mapper;
        public StudentController(IStudentRepository studentRepository, IMapper mapping)
        {
            stdRepo = studentRepository;
            mapper = mapping;
        }
        [HttpPost("AddStudent")]
        public async Task<ActionResult> Create([FromBody] StudentDTO studentDTO)
        {
            var Dob = studentDTO.DateOfBirth;
            var isStudent = stdRepo.IsStudentExists(studentDTO.Name, studentDTO.FatherName, studentDTO.MobileNo);
            if(isStudent)
            {
                return Ok(new
                {
                    statusCode = 200,
                    status = "success",
                    message = "Student is already exists",
                    data = (object)null
                });
            }
            else
            {
                var age = stdRepo.IsEligibleForAge(Dob);
                if(age)
                {
                    var student = mapper.Map<StudentsModel>(studentDTO);
                    await stdRepo.Create(student);
                    return Ok(new
                    {
                        statusCode = 200,
                        status = "success",
                        message = "Student Added successfully",
                        data = student
                    });

                }
                else
                {
                    return Ok(new
                    {
                        statusCode = 200,
                        status = "success",
                        message = "Student have not a valid Age",
                        data = (Object)null
                    });
                }

                
            }
        }
        [HttpGet("StudentsList")]
        public async Task<ActionResult<List<UpdateStudentDTO>>> GetAll()
        {
            var students = await stdRepo.GetAll();
            var std = mapper.Map<List<UpdateStudentDTO>>(students);
            if (std == null)
            {
                return Ok(new
                {
                    statusCode = 200,
                    status = "error",
                    message = "Student Not Found",
                    data = (object)null
                });
            }
            return Ok(new
            {
                statusCode = 200,
                status = "success",
                message = "Student List Below",
                data = std
            });
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<StudentsModel>> Delete(DeleteStudentDTO deleteDTO)
        {
            var students = await stdRepo.GetById(deleteDTO.Id);
            if(students == null)
            {
                return Ok(new
                {
                    statusCode = 200,
                    status = "error",
                    message = "Student Not Found",
                    data = (object) null
                });
            }
            
            students.IsDeleted = true;
            students.DeletedBy = deleteDTO.DeletedBy;
            students.DeletedAt = DateTime.UtcNow;
            await stdRepo.Update(students);
            return Ok(new
            {
                statusCode = 200,
                status = "success",
                message = "Student Details Deleted successfully",
                data = students
            });
        }

        [HttpPost("UpdateStudent")]
        public async Task<ActionResult> Update([FromBody] UpdateStudentDTO student)
        {
            if (student == null)
            {
                return Ok(new
                {
                    statusCode = 200,
                    status = "error",
                    message = "Invalid Request",
                    data = (object)null
                });
            }

            var studentFromDb = await stdRepo.GetById(student.Id);
            if (studentFromDb == null)
            {
                return Ok(new
                {
                    statusCode = 200,
                    status = "error",
                    message = "Student Not Found",
                    data = (object)null
                });
            }

            // Map the updated data from DTO to the existing database model
            var updatedStudent = mapper.Map(student, studentFromDb);

            // Update the student in the database
            await stdRepo.Update(updatedStudent);

            return Ok(new
            {
                statusCode = 200,
                status = "success",
                message = "Student Updated successfully",
                data = updatedStudent
            });
        }


    }
}
