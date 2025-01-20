export interface ResultInterface {
  data: LoginInterface;
  errors: [];
  succeeded: boolean;
}

export interface LoginInterface {
  idUserEncrypt?: string;
  name: string;
  user: string;
  password: string;
}
