import { Guid } from "guid-typescript";
import { Room } from "./room.model";

export interface Location
{
    id: Guid;
    city: string;
    rooms: Room[];
}