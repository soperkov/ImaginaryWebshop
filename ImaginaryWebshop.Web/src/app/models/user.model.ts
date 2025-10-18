export interface UserLoginDto {
    usernameOrEmail: string;
    password: string;
}

export interface RegistrationDto {
    username: string;
    email: string;
    password: string;
    confirmPassword: string;
}

export interface UserDetailsDto {
    id: string;
    username: string;
    email: string;
}