namespace WebFormsLove.Core.Views.Model
{
    public class FormMessageModel
    {
        public FormMessageModel()
        {
            Result = FormResult.None;
        }

        public FormResult Result { get; set; }
        public string Message { get; set; }

        public static FormMessageModel Success(string msg)
        {
            return new FormMessageModel {Result = FormResult.Success, Message = msg};
        }

        public static FormMessageModel Error(string msg)
        {
            return new FormMessageModel {Result = FormResult.Error, Message = msg};
        }
    }
}