import { Guid } from "guid-typescript";
import { Room } from "./room.model";
import { Film } from "./film.model";

export interface Screening
{
    screening_ID: Guid;
    room:number;
    film:string;
    time: Date;
    location: string;
    id_film: Guid;
    id_room: Guid;
    _room: Room[];
    _film: Film[];
}