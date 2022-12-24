import { Guid } from "guid-typescript";
import { Location } from "./location.model";
import { Ticket } from "./ticket.mode";
import { Screening } from "./screening.model";

export interface Room
{
    id: Guid;
    column: number;
    row: number;
    taken_steats: string;
    unavailable_steats: string;
    room_number: number;
    id_location: Guid;
    _location: Location[];
    tickets: Ticket[];
    screenings: Screening[];
}