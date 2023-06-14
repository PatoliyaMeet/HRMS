export class RegisterModel {

    public UserName: string =""
    public Email: string =""
    public PhoneNumber: string =""
    public Password: string =""
    public ConfirmPassword: string= ""


    constructor(userName:string,email:string,phonenumber:string, password:string, confirmpassword:string){
        this.UserName=userName
        this.Email = email  
        this.PhoneNumber = phonenumber  
        this.Password = password
        this.ConfirmPassword=confirmpassword

    }

    ngSubmit(){
        
    }
}
