export interface ResultInterface {
  data: {
    destinations: DestinationInterface[];
  };

  errors: [];
  succeeded: boolean;
}

export interface DestinationInterface {
  id: number;
  description: string;
}
