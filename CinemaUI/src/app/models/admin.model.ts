import { Guid } from "guid-typescript";

export interface Admin
{
    id: Guid;
    login: string;
    password: string;
}