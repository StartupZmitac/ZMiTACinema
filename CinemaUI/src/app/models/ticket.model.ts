import { Guid } from "guid-typescript";
import { Room } from "./room.model";

export interface Ticket
{
    id: Guid;
    isChecked: boolean;
    film: string;
    isPaid: boolean;
    room: number;
    seat: string;
    type: string;
    time: Date;
    id_room: Guid;
    _room: Room[];
}