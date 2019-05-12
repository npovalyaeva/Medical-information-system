//using Mapster;
//using MySql.Data.MySqlClient;
//using Specialist.Commands;
//using Specialist.Data;

//namespace Specialist.Handlers
//{
//    class CreateSpecialistHandler
//    {
//        private readonly SpecialistContext _context;

//        public CreateSpecialistHandler(SpecialistContext context)
//        {
//            _context = context;
//        }

//        public bool Handle(CreateSpecialistCommand request)
//        {
//            var model = request.Adapt<Model.Specialist>();
//            string tempHash = Hash.FindHash(model.PasswordHash);
//            model.PasswordHash = tempHash;

//            using (MySqlConnection conn = _context.GetConnection())
//            {
//                conn.Open();
//                string query = string.Format("INSERT INTO Specialists(last_name, first_name, middle_name, email, password_hash, Health_Facilities_faculty_id) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
//                    model.LastName, model.FirstName, model.MiddleName,
//                    model.Email, model.PasswordHash, model.HealthFacilitiesFacultyId);
//                MySqlCommand cmd = new MySqlCommand(query, conn);
//                try
//                {
//                    cmd.ExecuteNonQuery();
//                }
//                catch
//                {
//                    return false;
//                }
//                finally
//                {
//                    conn.CloseAsync();
//                }
//            }

//            return true;
//        }
//    }
//}
