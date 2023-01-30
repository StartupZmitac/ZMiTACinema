import { Guid } from "guid-typescript";
import { Location } from "./location.model";
import { Ticket } from "./ticket.model";
import { Screening } from "./screening.model";

export interface Room
{
    id: string;
    column: number;
    row: number;
    taken_seats: string;
    unavailable_seats: string;
    room_number: number;
    id_location: string;
    _location: Location[];
    tickets: Ticket[];
    screenings: Screening[];
}