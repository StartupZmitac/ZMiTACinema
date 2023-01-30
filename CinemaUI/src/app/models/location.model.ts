import { Guid } from "guid-typescript";
import { Room } from "./room.model";

export interface Location
{
    id: string;
    city: string;
    rooms: Room[];
}