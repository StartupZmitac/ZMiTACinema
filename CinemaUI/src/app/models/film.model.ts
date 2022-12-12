import { Guid } from "guid-typescript";
import { Screening } from "./screening.model";

export interface Film
{
    id: Guid;
    is3D: boolean;
    age: number;
    category: string;
    dubbing: boolean;
    imageSource: string;
    language: string;
    name:string;
    sub: boolean;
    time: number;
    screenings: Screening[];
}