import { Location } from "./location.model";

export interface customRoom
{
  column: number;
  row: number;
  taken_seats: string;
  unavailable_seats: string;
  room_number: number;
  _locationName: string;
}
