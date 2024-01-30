import ActorForm from "./ActorForm";

export default function EditActor() {
  return (
    <>
      <h3>Edit Actor</h3>
      <ActorForm
        model={{
          name: "Tom Holland",
          dateOfBirth: new Date("1996-06-01T00:00:00"),
          biography: `# Something
This person was born in **Kosovo**`,
          pictureURL: 'https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Tom_Cruise_by_Gage_Skidmore_2.jpg/800px-Tom_Cruise_by_Gage_Skidmore_2.jpg'
        }}
        onSubmit={(values) => console.log(values)}
      />
    </>
  );
}
