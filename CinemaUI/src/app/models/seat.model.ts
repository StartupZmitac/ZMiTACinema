export class Seat {
  number: string | undefined; //Index of seat
  selected: boolean = false; //Selected by user, who reserves right now
  isTaken: boolean = false; //Other user has already reserved this seat
  unavailable: boolean = false; //Not seen - used to display custom layout
}
